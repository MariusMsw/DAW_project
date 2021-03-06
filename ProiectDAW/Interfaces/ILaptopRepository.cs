﻿using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Interfaces
{
    public interface ILaptopRepository : IGenericRepository<Laptop>
    {
        public Laptop GetLaptopAllDetails(int LaptopId);

        public List<Laptop> GetLaptopsAllDetails();
    }
}
