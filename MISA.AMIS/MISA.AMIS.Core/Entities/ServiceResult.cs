using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    /// <summary>
    /// Kết quả trả về
    /// </summary>
    /// CreatedBy: DTSang(26/08)
     public class ServiceResult
    {
        #region Property
        /// <summary>
        /// Mã kết quả trả về
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public int Code { get; set; }

        /// <summary>
        /// thông báo trả về cho người dùng
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông báo trả về cho dev
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public string devMsg { get; set; }

        /// <summary>
        /// Dữ liệu trả
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public object Data { get; set; }

        #endregion

        #region Contructor
        /// <summary>
        /// Hàm khởi tạo ServiceResult
        /// </summary>
        /// CreatedBy: DTSang(26/08)
        public ServiceResult()
        {
            this.Code = (int)Enum.EnumResult.Success;
            this.UserMsg = null;
            this.devMsg = null;
            this.Data = null;
        }
        #endregion
    }
}
