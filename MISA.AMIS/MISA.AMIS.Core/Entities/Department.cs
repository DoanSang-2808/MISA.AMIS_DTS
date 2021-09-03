using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    /// <summary>
    /// Lớp đơn vị
    /// </summary>
    /// CreatedBy: DTSang(30/08)
    public class Department : Entity
    {

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy: DTSang(30/08)
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreatedBy: DTSang(30/08)
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        /// CreatedBy: DTSang(30/08)
        public string DepartmentName { get; set; }
        #endregion
    }
}
