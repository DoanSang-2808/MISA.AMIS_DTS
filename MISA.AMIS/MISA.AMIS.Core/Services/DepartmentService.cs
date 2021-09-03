using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class DepartmentService : BaseService<Department>
    {
        private IDepartmentRepository _departmentRepository;

        #region Contructor
        public DepartmentService(IDepartmentRepository departmentRepository, IBaseRepository<Department> baseRepository) : base(baseRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
    }
}
