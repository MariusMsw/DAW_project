using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
    public interface ILaptopService
    {
        public List<Laptop> GetLaptops();

        public Laptop GetLaptop(int id);

        public Laptop CreateLaptop(Laptop Laptop);

        public Laptop UpdateLaptop(int laptopId, Laptop Laptop);

        public bool DeleteLaptop(int id);
    }
}
