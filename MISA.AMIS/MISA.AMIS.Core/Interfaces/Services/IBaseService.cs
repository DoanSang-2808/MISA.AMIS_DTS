using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Services
{
    /// <summary>
    /// BaseService
    /// </summary>
    /// CreatedBy: DTSang(26/08)
    public interface IBaseService<T>
    {
        #region Methods
        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức lấy tất cả các bản ghi
        /// </summary>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(26/08)
        public ServiceResult GetAll();

        /// <summary>
        /// XỬ lí nghiệp vụ cho phương thức lấy một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Kêt quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(26/08)
        public ServiceResult GetById(Guid entityId);

        /// <summary>
        /// Xử lí nghiệp vu cho phương thức thêm mưới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(26/08)
        public ServiceResult Created(T entity);

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(26/08)
        public ServiceResult Update(T entity, Guid entityId);

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức xóa bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(26/08)
        public ServiceResult Delete(Guid entityId);

        #endregion

    }
}
