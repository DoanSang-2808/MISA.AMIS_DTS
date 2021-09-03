using Dapper;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {

        #region Declare
        protected string _table;
        protected string _connectString;
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public BaseRepository()
        {
            _table = typeof(T).Name;
            _connectString = "Host = localhost;" +
            "Database = misa.amis_dtsang;" +
            "User Id = root;";
            _dbConnection = new MySqlConnection(_connectString);
        }
        #endregion

        #region Methods

        #endregion
        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: DTsang(27/08)
        public int Created(T entity)
        {
            var columnsName = string.Empty;
            var columnsValue = string.Empty;
            DynamicParameters dynamicparam = new DynamicParameters();

            var properties = entity.GetType().GetProperties();
            foreach (var item in properties)
            {
                if (item.GetCustomAttributes(typeof(NotMap), true).Length == 0)
                {
                    var propname = item.Name;
                    var propvalue = item.GetValue(entity);
                    if (propname == $"{_table}Id" && item.PropertyType == typeof(Guid))
                    {
                        propvalue = Guid.NewGuid();
                    }
                    dynamicparam.Add($"@{propname}", propvalue);
                    columnsName += $"{propname},";
                    columnsValue += $"@{propname},";

                }

            }
            columnsName = columnsName.Remove(columnsName.Length - 1, 1);
            columnsValue = columnsValue.Remove(columnsValue.Length - 1, 1);
            var sqlCommand = $"INSERT INTO {_table} ({columnsName}) VALUES({columnsValue})";
            //int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicparam);
            //return rowAffects;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicparam, transaction);
                transaction.Commit();
                return rowAffects;
            }
        }

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: DTsang(27/08)
        public int Delete(Guid entityId)
        {
            DynamicParameters DynamicParam = new DynamicParameters();
            var sqlCommand = $"DELETE FROM {_table} WHERE {_table}Id = @IdParam";
            Console.WriteLine(sqlCommand);
            DynamicParam.Add("@IdParam", entityId);
            int rowEffect = _dbConnection.Execute(sqlCommand, DynamicParam);

            return rowEffect;
        }

        /// <summary>
        /// Lấ toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: DTsang(27/08)
        public List<T> GetAll()
        {
            var sqlcommand = $"Proc_Get{_table}s";
            var entities = _dbConnection.Query<T>(sqlcommand, commandType: CommandType.StoredProcedure).ToList();

            return entities;
        }

        /// <summary>
        /// Láy một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: DTsang(27/08)
        public T GetById(Guid entityId)
        {
            DynamicParameters DynamicParam = new DynamicParameters();
            var sqlCommand = $"Proc_Get{_table}ById";
            DynamicParam.Add($"@{_table}Id", entityId.ToString());
            var entity = _dbConnection.QueryFirstOrDefault<T>(sqlCommand, param: DynamicParam, commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: DTsang(27/08)
        public int Update(T entity, Guid entityId)
        {
            DynamicParameters dynamicparam = new DynamicParameters();
            var sqlCommand = $"Proc_Update{_table}";
            var properties = entity.GetType().GetProperties();

            foreach (var item in properties)
            {
                if (item.GetCustomAttributes(typeof(NotMap), true).Length == 0)
                {
                    var propname = item.Name;

                    var propvalue = item.GetValue(entity) == "" ? null : item.GetValue(entity);

                    dynamicparam.Add($"@{propname}", propvalue);

                }
            }
            dynamicparam.Add($"@{_table}id", entityId.ToString());

            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                int rowAffects = _dbConnection.Execute(sqlCommand, param: dynamicparam, transaction, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                return rowAffects;
            }
        }

        /// <summary>
        /// Ngắt kết nối sơ sở dữ liệu
        /// </summary>
        /// CreatedBy: DTsang(27/08)
        public void Dispose()
        {
            this._dbConnection.Dispose();
        }

        /// <summary>
        /// Kiểm tra dữ liệu đã tồn tại hay chưa
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="id"></param>
        /// <returns>Trả về bản ghi tương ứng với dữ liệu truyền vào </returns>
        /// CreatedBy: DTSang(28/08)
        public T CheckDuplicate(string propertyName, string propertyValue, Guid id)
        {
            DynamicParameters DynamicParam = new DynamicParameters();
            var sqlCommand = $"Proc_CheckDuplicate{propertyName}";
            DynamicParam.Add("@PropertyValue", propertyValue);
            DynamicParam.Add("@Id", id);
            var entity = _dbConnection.QueryFirstOrDefault<T>(sqlCommand, param: DynamicParam, commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}
