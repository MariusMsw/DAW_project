using ProiectDAW.Data;
using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(Context context) : base(context)
        {

        }

        public Department GetDepartmentByName(string name)
        {
            return _table.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
