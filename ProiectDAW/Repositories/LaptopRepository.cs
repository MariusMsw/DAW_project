using Microsoft.EntityFrameworkCore;
using ProiectDAW.Data;
using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProiectDAW.Repositories
{
    public class LaptopRepository : GenericRepository<Laptop>, ILaptopRepository
    {
        public LaptopRepository(Context context) : base(context)
        {

        }

        public Laptop GetLaptopAllDetails(int LaptopId)
        {
            return _table.Where(lap => lap.LaptopId == LaptopId)
                .Include(lap => lap.Employee)
                .ThenInclude(emp => emp.Department)
                .FirstOrDefault();
        }

        public List<Laptop> GetLaptopsAllDetails()
        {
            return _table.Include(lap => lap.Employee)
                .ThenInclude(emp => emp.Department).ToList();
        }
    }
}
