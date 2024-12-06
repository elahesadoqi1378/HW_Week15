using HW_Week15.Contracts.Repositories;
using HW_Week15.DAL.Repositories;
using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HW_Week15.Services.UserService;

namespace HW_Week15.Services
{
    public class UserService
    {
        
            private readonly IUserRepository userRepository;

            public UserService()
            {
                userRepository =new UserRepository();
            }

            public User GetUserByCardNumber(string cardNumber)
            {
                return userRepository.Get(cardNumber);
            }
        }

    
}
