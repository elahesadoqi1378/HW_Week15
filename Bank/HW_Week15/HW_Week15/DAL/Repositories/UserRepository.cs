using HW_Week15.Contracts.Repositories;
using HW_Week15.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDBContext appDBContext;

        public UserRepository()
        {
            appDBContext = new AppDBContext();
        }
        public User Get(string cardNumber)
        {
            return appDBContext.Users.FirstOrDefault(u => u.Cards.Any(c => c.CardNumber == cardNumber));

        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }
    }
}
