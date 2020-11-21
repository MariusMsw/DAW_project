using ProiectDAW.Data;
using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {

        }

        public User GetByMail(string mail)
        {
            return _table.Where(x => x.Mail == mail).FirstOrDefault();
        }

        public User GetByUserAndPassword(string mail, string password)
        {
            return _table.Where(x => x.Mail == mail && x.Password == password).FirstOrDefault();
        }
    }
}
