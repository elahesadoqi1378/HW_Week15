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
    public class TransactionRepository : ITransactionRepository
    {
        AppDBContext appDBContext;

        public TransactionRepository()
        {
            appDBContext = new AppDBContext();
        }
        public void Add(Transaction transaction)
        {
            appDBContext.Transactions.Add(transaction);
           appDBContext.SaveChanges();
        }

        public List<Transaction> GetTransactionsBy(string cardNumber)
        {
            return appDBContext.Transactions
                      .Where(t => t.SourceCardNumber == cardNumber || t.DestinationCardNumber == cardNumber)
                      .ToList();
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }
    }
}
