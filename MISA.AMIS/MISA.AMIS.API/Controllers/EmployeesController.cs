using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        #region Declare
        private IEmployeeService _employeeService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private const string _excelName = "Danh_sach_nhan_vien.xlsx";
        #endregion
        public EmployeesController(IEmployeeService employeeService, IBaseService<Employee> baseService, IHostingEnvironment hostingEnvironment) : base(baseService)
        {
            this._employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [Route("Pagging")]
        public IActionResult EmployeePagging(string keySearch, int pageIndex, int pageSize)
        {
            ServiceResult serviceResult = _employeeService.GetEmployeePaging(keySearch, pageIndex, pageSize);
            return Ok(serviceResult);
        }
        /// <summary>
        /// Phương thức lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            ServiceResult serviceResult = _employeeService.GetNewEmployeeCode();
            return Ok(serviceResult);
        }

        [HttpGet]
        [Route("Export")]
        public IActionResult ExportEmployees()
        {
            
                // đường dẫn đến wwwroot
                string folder = _hostingEnvironment.WebRootPath;
                // file download
                string urlDownload = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, _excelName);
                // tạo file với đường dẫn wwwroot, tên là danh_sach_nhan_vien
                var file = new FileInfo(Path.Combine(folder, _excelName));
                if (file.Exists)
                {
                    // xóa file cũ nếu đã tồn tại
                    file.Delete();
                    // khởi tạo ra file mới tên là danh_sach_nhan_vien
                    file = new FileInfo(Path.Combine(folder, _excelName));
                }

                var result = _employeeService.ExportEmployees(folder);
                result.Data = urlDownload;
                return Ok(result);
        }
    }
}
