using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using ProiectDAW.IServices;
using System.Collections.Generic;

namespace ProiectDAW.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;

        public LaptopService(ILaptopRepository LaptopRepository)
        {
            this._laptopRepository = LaptopRepository;
        }

        public Laptop CreateLaptop(Laptop Laptop)
        {
            _laptopRepository.Create(Laptop);
            _laptopRepository.SaveChanges();
            return Laptop;
        }

        public bool DeleteLaptop(int LaptopId)
        {
            Laptop Laptop = _laptopRepository.FindById(LaptopId);
            if (Laptop == null)
            {
                return false;
            }

            _laptopRepository.Delete(Laptop);
            _laptopRepository.SaveChanges();

            return true;
        }

        public Laptop GetLaptop(int LaptopId)
        {
            return _laptopRepository.FindById(LaptopId);
        }

        public List<Laptop> GetLaptops()
        {
            return _laptopRepository.GetAll();
        }

        public Laptop UpdateLaptop(int LaptopId, Laptop Laptop)
        {
            Laptop ExistingLaptop = _laptopRepository.FindById(LaptopId);
            if (ExistingLaptop == null)
            {
                return null;
            }

            ExistingLaptop.Brand = Laptop.Brand;
            ExistingLaptop.CPU = Laptop.CPU;
            ExistingLaptop.Employee = Laptop.Employee;
            ExistingLaptop.OS = Laptop.OS;
            ExistingLaptop.RAM = Laptop.RAM;

            _laptopRepository.Update(ExistingLaptop);
            _laptopRepository.SaveChanges();

            return ExistingLaptop;
        }
    }
}
