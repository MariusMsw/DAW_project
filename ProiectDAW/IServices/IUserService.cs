using ProiectDAW.Entities;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        bool Register(RegisterRequest request);
        AuthenticationResponse Login(AuthenticationRequest request);
    }
}
