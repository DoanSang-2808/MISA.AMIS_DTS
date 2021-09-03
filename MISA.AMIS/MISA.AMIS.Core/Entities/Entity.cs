using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{

    /// <summary>
    /// Cờ Required yêu cầu không để trống
    /// </summary>
    /// CreatedBy: DTSang(26/08)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    /// <summary>
    /// Cờ Duplication thông báo thông tin không được trùng
    /// </summary>
    /// CreatedBy: DTSang(26/08)
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplication : Attribute
    {

    }

    /// <summary>
    /// Cờ Email yêu cầu thông tin email phải đúng đinh dạng
    /// </summary>
    /// CreatedBy: DTSang(26/08)
    public class Email : Attribute
    {

    }
    /// <summary>
    /// Đánh dấu property không maping
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotMap : Attribute
    {

    }

    /// <summary>
    /// Các property chung
    /// </summary>
    /// CreatedBy: DTSang(26/08)
    public class Entity
    {
        #region Property
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa bản ghi gần nhất
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa bản ghi gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
