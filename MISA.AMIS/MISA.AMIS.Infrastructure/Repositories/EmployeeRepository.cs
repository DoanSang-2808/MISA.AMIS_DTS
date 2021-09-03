using Dapper;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public object GetEmployeePaging(string keySearch, int pageIndex, int pageSize)
        {
            var keywork = keySearch == null ? string.Empty : keySearch;
            DynamicParameters DynamicParam = new DynamicParameters();
            var sqlcommand = "Proc_GetEmployeesByPaging";
            DynamicParam.Add("@KeySearch", keywork);
            DynamicParam.Add("@PageIndex", pageIndex);
            DynamicParam.Add("@PageSize", pageSize);
            DynamicParam.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            DynamicParam.Add("@TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var employees = _dbConnection.Query<Employee>(sqlcommand, param: DynamicParam, commandType: CommandType.StoredProcedure);
            var totalRecord = DynamicParam.Get<int>("@TotalRecord");
            var totalPage = DynamicParam.Get<int>("@TotalPage");

            var result = new
            {
                TotalRecord = totalRecord,
                TotalPage = totalPage,
                Employees = employees
            };

            return result;
        }

        public string GetNewEmployeeCode()
        {
            var sqlcommand = "Proc_GetNewemployeeCode";
            var code = _dbConnection.QueryFirstOrDefault<string>(sqlcommand, commandType: CommandType.StoredProcedure);

            string changeValue = "";
            int plus = 1;
            int brk = 0;
            for (int i = code.Length - 1; i >= 0; i--)
            {
                brk = i;
                if (code[i] >= '0' && code[i] <= '9')
                {
                    int n = (int)(code[i] - '0');
                    if (n + plus >= 10)
                    {
                        int v = (n + plus) - 10;
                        plus = 1;
                        changeValue = v.ToString() + changeValue;
                    }
                    else
                    {
                        changeValue = (n + plus).ToString() + changeValue;
                        break;
                    }
                }
                else
                {
                    brk += 1;
                    changeValue = plus.ToString() + changeValue;
                    break;
                }
            }
            return code.Substring(0, brk) + changeValue;
        }
    }
}
