using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region Methods
        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức lấy mã nhân viên mới
        /// </summary>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        public ServiceResult GetNewEmployeeCode();

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức phân trang nhân viên
        /// </summary>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        public ServiceResult GetEmployeePaging(string keySearch, int pageIndex, int pageSize);

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức xuất dữ liệu
        /// </summary>
        /// <param name="folder"></param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        public ServiceResult ExportEmployees(string folder);
        #endregion

        /// <summary>
        /// Xử lí nghiệp vụ cho trường Gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns>Trả về kết quả sử lí nghiệp vụ</returns>
        public string GenderName(int gender);
    }

}
