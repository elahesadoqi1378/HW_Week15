using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Contracts.Repositories
{
    public interface ICardRepository
    {
        Card Get(string cardNumber);
        void Update(Card card);
        void Save();
    }

}
