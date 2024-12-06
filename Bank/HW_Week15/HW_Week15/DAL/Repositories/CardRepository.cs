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
    public class CardRepository : ICardRepository
    {
        AppDBContext appDBContext;

        public CardRepository()
        {
            appDBContext = new AppDBContext();
        }
        public Card Get(string cardNumber)
        {
            return appDBContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
        }

        public void Save()
        {
            appDBContext.SaveChanges();
        }

        public void Update(Card card)
        {
            var existingCard =  appDBContext.Cards.FirstOrDefault(c => c.Id == card.Id);
            if (existingCard != null)
            {
                existingCard.Balance = card.Balance;
                existingCard.IsActive = card.IsActive;
                existingCard.Password = card.Password;
                existingCard.FailedLoginAttempts = card.FailedLoginAttempts;
            }
            appDBContext.SaveChanges();
        }
    }
}
