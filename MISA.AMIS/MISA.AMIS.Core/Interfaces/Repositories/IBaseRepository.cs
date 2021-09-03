using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
   /// <summary>
   /// BaseRepository
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// CreatedBy: DTSang(26/08)
    public interface IBaseRepository<T>
    {
        #region Methods
        /// <summary>
        /// Phương thức lấy tất cả các bản ghi
        /// </summary>
        /// <returns> Danh sách các bản ghi</returns>
        /// CreatedBy: DTSang(26/08)
        public List<T> GetAll();

        /// <summary>
        /// phương thức lấy một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>bản ghi muốn lấy</returns>
        /// CreatedBy: DTSang(26/08)
        public T GetById(Guid entityId);

        /// <summary>
        /// Phương thức thêm một bản ghi mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>trạng thái sau khi bản ghi được thêm</returns>
        /// CreatedBy: DTSang(26/08)
        public int Created(T entity);

        /// <summary>
        /// Phương thức cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns>trạng thái ssau khi bản ghi được cập nhật</returns>
        /// CreatedBy: DTSang(26/08)
        public int Update(T entity, Guid entityId);

        /// <summary>
        /// Phương thức xóa một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>trạng thái sau khi bản ghi được xóa</returns>
        /// CreatedBy: DTSang(26/08)
        public int Delete(Guid entityId);

        /// <summary>
        /// phương thức lấy về bản ghi theo thuộc tính
        /// </summary>
        /// <param name="propetyName"></param>
        /// <param name="propertyvalue"></param>
        ///  <returns>Bản ghi đang tìm kiếm</returns>
        /// CreatedBy: DTSang(28/08)
        public T CheckDuplicate(string propertyName, string propertyValue, Guid id);
        #endregion
    }
}
