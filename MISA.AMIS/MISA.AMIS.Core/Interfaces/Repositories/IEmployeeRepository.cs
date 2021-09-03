using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        #region Methods
        /// <summary>
        /// Phương thức lấy về mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy: DTSang(26/08)
        public string GetNewEmployeeCode();

        /// <summary>
        /// Phương thức phân trang nhân viên
        /// </summary>
        /// <param name="keySearch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>Danh sách bản ghi theo phân trang</returns>
        /// CreatedBy: DTSang(26/08)
        public object GetEmployeePaging(string keySearch, int pageIndex, int pageSize);
        #endregion
    }
}
