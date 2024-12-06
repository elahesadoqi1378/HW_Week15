using HW_Week15.Contracts.Repositories;
using HW_Week15.DAL.Repositories;
using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Services
{
    public class TransactionService 
    {
        private readonly ITransactionRepository transactionRepository;
       

        public TransactionService()
        {
            transactionRepository =  new TransactionRepository();
          
        }

        public void AddTransaction(Transaction transaction)
        {
            transactionRepository.Add(transaction);
        }

        public List<Transaction> GetTransactionsByCardNumber(string cardNumber)
        {
            return transactionRepository.GetTransactionsBy(cardNumber);
        }
    }

}
