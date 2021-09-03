using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MISA.AMIS.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Property
        protected IBaseRepository<T> _baseRepository;
        protected ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức tạo bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(28/08)
        public ServiceResult Created(T entity)
       {
            var id = Guid.Empty;
            _serviceResult = Validate(entity, id);
            if(_serviceResult.Code == (int)Enum.EnumResult.Success)
            {
                try
                {
                    int result = _baseRepository.Created(entity);
                    if(result > 0)
                    {
                        _serviceResult.Code = (int)Enum.EnumResult.Created;
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
            }
            return _serviceResult;
        }

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức xóa một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns> Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(28/08)
        public ServiceResult Delete(Guid entityId)
        {
            try
            {
                var result = _baseRepository.Delete(entityId);
                if(result > 0)
                {
                    _serviceResult.Code = (int)Enum.EnumResult.Success;
                    _serviceResult.UserMsg = Resources.ResourceVN.Success;
                    _serviceResult.devMsg = Resources.ResourceVN.Success;
                    _serviceResult.Data = result;
                }
                else
                {
                    _serviceResult.Code = (int)Enum.EnumResult.BadRequest;
                    _serviceResult.UserMsg = Resources.ResourceVN.User_BadRequest_Msg;
                    _serviceResult.devMsg = $"Không tìm được bản ghi ứng với mã {entityId.ToString()}";
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
        /// Xử lí nghiệp vụ cho phương thức lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTsang(28/08)
        public ServiceResult GetAll()
        {
            try
            {
                var result = _baseRepository.GetAll();
                if (result.Count() > 0)
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
                _serviceResult.devMsg =ex.Message;
            }
            
            return _serviceResult;
        }

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thức lấy một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTsang(28/08)
        public ServiceResult GetById(Guid entityId)
        {
            try
            {
                var result = _baseRepository.GetById(entityId);
                if(result != null)
                {
                    _serviceResult.Code = (int)Enum.EnumResult.Success;
                    _serviceResult.UserMsg = Resources.ResourceVN.Success;
                    _serviceResult.devMsg = Resources.ResourceVN.Success;
                    _serviceResult.Data = result;
                }
                else
                {
                    _serviceResult.Code = (int)Enum.EnumResult.BadRequest;
                    _serviceResult.UserMsg = Resources.ResourceVN.User_BadRequest_Msg;
                    _serviceResult.devMsg = $"Không tìm được bản ghi ứng với mã {entityId.ToString()}";
                    _serviceResult.Data = result;
                }
            
            }
            catch (Exception ex)
            {

                _serviceResult.Code = (int) Enum.EnumResult.InternalServerError;
                _serviceResult.UserMsg = Resources.ResourceVN.User_Error_Serve_Msg;
                _serviceResult.devMsg =ex.Message;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Xử lí nghiệp vụ cho phương thứ sửa bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns>Trả về kết quả xử lí nghiệp vụ</returns>
        /// CreatedBy: DTSang(28/08)
        public ServiceResult Update(T entity, Guid entityId)
        {
            _serviceResult = Validate(entity, entityId);
            if (_serviceResult.Code == (int)Enum.EnumResult.Success)
            {
                try
                {
                    int result = _baseRepository.Update(entity, entityId);
                    if (result > 0)
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
            }
            return _serviceResult;
        }

        /// <summary>
        /// Kiểm tra dữ liệu đầu vào
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>thoong tin sau khi validate</returns>
        /// CreatedBy: DTsang(28/08)
        private ServiceResult Validate(T entity, Guid id)
        {
            try
            {
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entity) == "" ? null : property.GetValue(entity);
                    if(property.GetCustomAttributes(typeof(Required), true).Length > 0)
                    {
                        if(IsNull(propertyValue) == true)
                        {
                            _serviceResult.Code = (int)Enum.EnumResult.BadRequest;
                            _serviceResult.UserMsg = string.Format(Resources.ResourceVN.Input_Empty, propertyName);
                            _serviceResult.devMsg = string.Format(Resources.ResourceVN.Input_Empty, propertyName);
                        }
                    }
                    if(property.GetCustomAttributes(typeof(Duplication), true).Length > 0)
                    {
                        if(IsDuplicate(propertyName, (string)propertyValue, id) == true)
                        {
                            _serviceResult.Code = (int)Enum.EnumResult.BadRequest;
                            _serviceResult.UserMsg = string.Format(Resources.ResourceVN.Input_Duplicate, propertyName);
                            _serviceResult.devMsg = string.Format(Resources.ResourceVN.Input_Duplicate, propertyName);
                        }
                    }
                    if(property.GetCustomAttributes(typeof(Email), true).Length > 0)
                    {
                        if(IsNotEmail((string)propertyValue) == true)
                        {
                            _serviceResult.Code = (int)Enum.EnumResult.BadRequest;
                            _serviceResult.UserMsg = string.Format(Resources.ResourceVN.Input_Format, propertyName);
                            _serviceResult.devMsg = string.Format(Resources.ResourceVN.Input_Format, propertyName);
                        }
                    }
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
        /// Kiểm tra dữ liệu đầu vào có trống hay không
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Trả về true nếu dữ liệu trống và false nếu ngược lại</returns>
        /// CreatedBy: DTSang(28/08)
        private bool IsNull(object value)
        {
            if(string.IsNullOrEmpty(Convert.ToString(value)) || value == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra dữ liệu đã tòn tại trong cơ sở dữ liệu chưa chưa
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="id"></param>
        /// <returns>Trả về true nếu dữ liệu đã tồn tại và ngược lại trả về false</returns>
        /// CreatedBy: DTSang(28/08)
        private bool IsDuplicate(string propertyName, string propertyValue, Guid id)
        {
            if(_baseRepository.CheckDuplicate(propertyName, propertyValue, id) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra định djng Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Trả về true nếu khôn gđúng định dạng và ngược lại trả về false</returns>
        /// CreatedBy: DTSang(28/08)
        private bool IsNotEmail(string email)
        {
            if(email == null)
            {
                return false;
            }
            string format = @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;,.]{0,1}\s*)+$";
            var isMatch = Regex.IsMatch(email, format, RegexOptions.IgnoreCase);
            if (isMatch == false)
            {
                return true;
            }
            return false;
        }
    }
}
