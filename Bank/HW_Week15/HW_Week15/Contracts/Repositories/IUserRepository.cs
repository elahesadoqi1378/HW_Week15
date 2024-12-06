using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Contracts.Repositories
{
    public interface IUserRepository
    {
        User Get(string cardNumber);
        void Save();
    }
}
