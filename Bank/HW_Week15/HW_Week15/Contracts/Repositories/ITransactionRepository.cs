using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Contracts.Repositories
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        List<Transaction> GetTransactionsBy(string cardNumber);
        void Save();

    }
}
