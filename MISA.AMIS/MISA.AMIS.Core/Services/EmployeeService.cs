using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
     public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        #region Contructor
        public EmployeeService(IEmployeeRepository employeeRepository, IBaseRepository<Employee> baseRepository) : base(baseRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public ServiceResult ExportEmployees(string fordel)
        {
            try
            {
                // tạo file với đường dẫn wwwroot, tên là danh_sach_nhan_vien
                var file = new FileInfo(Path.Combine(fordel, "Danh_sach_nhan_vien.xlsx"));

                using (var package = new ExcelPackage(file))
                {
                    // tên worksheet
                    var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

                    // custom Title
                    workSheet.Cells["A1:I1"].Merge = true; //Trộn các ô của dòng 1 
                    workSheet.Cells["A1:I1"].Value = "DANH SÁCH NHÂN VIÊN"; // Nhập giá trị cho ô excel
                    workSheet.Cells["A1:I1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Căn giữ tiêu đề
                    workSheet.Cells["A1:I1"].Style.Font.Name = "Arial"; // Iiểu chữ Title
                    workSheet.Cells["A1:I1"].Style.Font.Size = 16; // Cỡ  chữ của title
                    workSheet.Cells["A1:I1"].Style.Font.Bold = true; // Viền cảu ô Title
                    workSheet.Cells["A2:I2"].Merge = true; // Trộng các ô của dòng 2

                    // custom thead bảng excel ở dòng
                    workSheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; //Thead căn giữa 
                    workSheet.Row(3).Style.Font.Bold = true; //Tạo border cho Thead
                    workSheet.Row(3).Style.Font.Name = "Arial"; // Kiểu chữ của Thead
                    workSheet.Row(3).Style.Font.Size = 10; // Cỡ chữu của Thead

                    // set color cho thead
                    workSheet.Cells["A3:I3"].Style.Fill.PatternType = ExcelFillStyle.Solid; //Xét kiểu cho border
                    workSheet.Cells["A3:I3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#cccccc")); // Set màu cho Thead #ccc

                    // thead: Tiêu đề các cột 
                    workSheet.Cells[3, 1].Value = "STT";
                    workSheet.Cells[3, 2].Value = "Mã nhân viên";
                    workSheet.Cells[3, 3].Value = "Tên nhân viên";
                    workSheet.Cells[3, 4].Value = "Giới tính";
                    workSheet.Cells[3, 5].Value = "Ngày sinh";
                    workSheet.Cells[3, 6].Value = "Chức danh";
                    workSheet.Cells[3, 7].Value = "Tên đơn vị";
                    workSheet.Cells[3, 8].Value = "Số tài khoản";
                    workSheet.Cells[3, 9].Value = "Tên ngân hàng";

                    // lấy danh sách nhân viên
                    var employees = _employeeRepository.GetAll(); // Gọi phương thức lấy toàn bộ nhân viên
                    int row = 4;
                    int count = 1;
                    foreach (var employee in employees)
                    {
                        // bind data lên column
                        workSheet.Cells[row, 1].Value = count;
                        workSheet.Cells[row, 2].Value = employee.EmployeeCode;
                        workSheet.Cells[row, 3].Value = employee.FullName;
                        workSheet.Cells[row, 4].Value = employee.Gender != null ? GenderName((int)employee.Gender) :  ""; // Format Gender
                        workSheet.Cells[row, 5].Value = employee.DateOfBirth != null ? Convert.ToDateTime(employee.DateOfBirth).ToString("dd/MM/yyyy") : ""; // Format DateOfBirth
                        workSheet.Cells[row, 6].Value = employee.PositionName;
                        workSheet.Cells[row, 7].Value = employee.DepartmentName;
                        workSheet.Cells[row, 8].Value = employee.BankAccount;
                        workSheet.Cells[row, 9].Value = employee.BankName;
                      

                        // custom column stt và column dob
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        workSheet.Cells[row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        // custom cỡ chữ cho row
                        workSheet.Row(row).Style.Font.Name = "Times New Roman";
                        workSheet.Row(row).Style.Font.Size = 11;
                        row++;
                        count++;
                    }

                    // length file excel
                    string modelRange = "A3:K" + (employees.Count() + 3).ToString();
                    var modelTable = workSheet.Cells[modelRange];

                    // thêm border
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    // fix width cho từng column
                    workSheet.Column(1).AutoFit();
                    workSheet.Column(2).AutoFit();
                    workSheet.Column(3).AutoFit();
                    workSheet.Column(4).AutoFit();
                    workSheet.Column(5).AutoFit();
                    workSheet.Column(6).AutoFit();
                    workSheet.Column(7).AutoFit();
                    workSheet.Column(8).AutoFit();
                    workSheet.Column(9).AutoFit();

                    package.Save();
                }
                _serviceResult.Code = (int)Enum.EnumResult.Success;
                _serviceResult.UserMsg = Resources.ResourceVN.Success;
               
            }
            catch (Exception ex)
            {
                _serviceResult.Code = (int)Enum.EnumResult.InternalServerError;
                _serviceResult.UserMsg = Resources.ResourceVN.User_Error_Serve_Msg;
                _serviceResult.devMsg = ex.Message;
                
            }
            return _serviceResult;
        }

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức phân trang và filter
        /// </summary>
        /// <param name="keySearch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        public ServiceResult GetEmployeePaging(string keySearch, int pageIndex, int pageSize)
        {
            try
            {
                var result = _employeeRepository.GetEmployeePaging(keySearch, pageIndex, pageSize);
                if (result != null)
                {
                    _serviceResult.Code = (int)Enum.EnumResult.Success;
                    _serviceResult.UserMsg = Resources.ResourceVN.Success;
                    _serviceResult.devMsg = Resources.ResourceVN.Success;
                    _serviceResult.Data = result;
                }
                else
                {
                    _serviceResult.Code = (int)Enum.EnumResult.NoContent;
                    _serviceResult.UserMsg = Resources.ResourceVN.User_Error;
                    _serviceResult.devMsg = Resources.ResourceVN.Dev_Error;
                    _serviceResult.Data = result;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Code = (int)Enum.EnumResult.InternalServerError;
                _serviceResult.UserMsg = Resources.ResourceVN.User_Error_Serve_Msg;
                _serviceResult.devMsg = ex.Message;
            }

            return _serviceResult;
        }

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức lấy mã nhân viên mới
        /// </summary>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        public ServiceResult GetNewEmployeeCode()
        {
            try
            {
                var employeeCode = _employeeRepository.GetNewEmployeeCode();
                if (employeeCode != null)
                {
                    _serviceResult.Code = (int)Enum.EnumResult.Success;
                    _serviceResult.UserMsg = Resources.ResourceVN.Success;
                    _serviceResult.devMsg = Resources.ResourceVN.Success;
                    _serviceResult.Data = employeeCode;
                }
                else
                {
                    _serviceResult.Code = (int)Enum.EnumResult.NoContent;
                    _serviceResult.UserMsg = Resources.ResourceVN.User_Error;
                    _serviceResult.devMsg = Resources.ResourceVN.Dev_Error;
                    _serviceResult.Data = employeeCode;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Code = (int)Enum.EnumResult.InternalServerError;
                _serviceResult.UserMsg = Resources.ResourceVN.User_Error_Serve_Msg;
                _serviceResult.devMsg = ex.Message;
            }
            return _serviceResult;
        }
        public string GenderName(int gender)
        {
            var result = string.Empty;
            switch (gender)
            {
                case 0 :
                    result = "Nữ";
                    break;
                case 1:
                    result = "Nam";
                    break;
                case 2:
                    result = "Khác";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }

        #endregion
    }
}
