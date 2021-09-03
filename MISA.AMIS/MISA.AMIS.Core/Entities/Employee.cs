using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    /// <summary>
    /// Lớp nhân viên
    /// </summary>
    /// CreatedBy: DTSang(26/08)
    public class Employee : Entity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        [Required]
        [Duplication]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        [Email]
        public string Email { get; set; }

        /// <summary>
        /// Số chứng minh thử, thẻ căn cước
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Số điện thoại 
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại 
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string LandlineNumber { get; set; }


        /// <summary>
        /// Mã vị trí
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string PositionName { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        [NotMap]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string Address { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string BankBranch { get; set; }
        #endregion
    }
}
