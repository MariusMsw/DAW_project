﻿using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUserAndPassword(string mail, string password);

        User GetByMail(string mail);
    }
}
