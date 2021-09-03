using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces.Services;
using MISA.AMIS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Declare
        protected IBaseService<T> _baseService;
        #endregion

        #region Construsctor
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        /// <summary>
        /// Phương thức lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>dang sách các bản ghi </returns>
        /// CreatedBy: DTSang(27/08)
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _baseService.GetAll();
            return Ok(entities);
           
        }

        /// <summary>
        /// Phương thức lấy một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Một bản ghi</returns>
        /// CreatedBy: DTSang(27/08)
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            var entity = _baseService.GetById(entityId);
                return Ok(entity);
           
        }

        /// <summary>
        /// Phương thức thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: DTSang(27/08)
        [HttpPost]
        public IActionResult Created(T entity)
        {
            var result = _baseService.Created(entity);
            return Ok(result);
        }

        /// <summary>
        /// Phương thức cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: DTSang(27/08)
        [HttpPut("{entityId}")]
        public IActionResult Update(T entity, Guid entityId)
        {
            var result = _baseService.Update(entity, entityId);
            return Ok(result);
        }

        /// <summary>
        /// Phương thức xóa bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: DTSang(27/08)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var result = _baseService.Delete(entityId);
            return Ok(result);
        }

    }
}
