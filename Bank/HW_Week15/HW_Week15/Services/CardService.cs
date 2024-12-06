
using HW_Week15.Contracts.Repositories;
using HW_Week15.DAL.Repositories;
using HW_Week15.Entities;

namespace HW_Week15.Services
{
    public class CardService
    {
        private readonly ICardRepository cardRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IUserRepository userRepository;
       
        

        public CardService()
        {
            cardRepository = new CardRepository();
            transactionRepository = new TransactionRepository();
            userRepository = new UserRepository();
        }

    

    public string Transfer(string sourceCardNumber, string destinationCardNumber, float amount)
        {
            
            if (sourceCardNumber.Length != 16 || destinationCardNumber.Length != 16)
                return "Card numbers must be 16 digits.";

            if (amount <= 0)
                return "Transfer amount must be greater than zero.";

            var sourceCard = cardRepository.Get(sourceCardNumber);
            var destinationCard = cardRepository.Get(destinationCardNumber);

            if (sourceCard == null || destinationCard == null)
                return "Invalid card number.";

            if (sourceCard.Balance < amount)
                return "Insufficient balance.";

            Console.WriteLine($" This Amount is tranfering  to: {destinationCard.HolderName}");
            Console.WriteLine("Do you confirm the transfer? (yes/no): ");
            var confirmation = Console.ReadLine();
            if (confirmation?.ToLower() != "yes")
            {
                return "Transfer cancelled by user.";
            }

            if (!sourceCard.IsActive)
            {

                return "Source card is inactive.";
               
            }

            var user = userRepository.Get(sourceCardNumber);
            if (user == null)
                return "User not found.";

            if (DailyLimit(sourceCardNumber, amount))
                return "Transfer limit exceeded for today.";


            float fee = TransactionFee(amount);
            float totalAmount = amount + fee;

            if (sourceCard.Balance < totalAmount)
                return "Insufficient balance including transaction fee.";

          
            var transaction = new Transaction
            {
                SourceCardNumber = sourceCardNumber,
                DestinationCardNumber = destinationCardNumber,
                Amount = amount,
                IsSuccessful = false,
                TransactionDate = DateTime.Now
            };

            
                sourceCard.Balance -= totalAmount;
                destinationCard.Balance += amount;

                cardRepository.Update(sourceCard);
                cardRepository.Update(destinationCard);
                transactionRepository.Add(transaction);

                
                transaction.IsSuccessful = true;
                transactionRepository.Save();

                return "Transfer successful.";
            
        }

        public List<Transaction> GetTransactions(string cardNumber)
        {
            return transactionRepository.GetTransactionsBy(cardNumber);
        }

        public bool ValidatePassword(string cardNumber, string password)
        {
            var card = cardRepository.Get(cardNumber);
            if (card != null && !card.IsActive)
            {
                Console.WriteLine("Your card is blocked. Please contact support.");
                return false;
            }

            if (card != null && card.Password == password)
            {
                card.FailedLoginAttempts = 0; 
                cardRepository.Update(card);
                return true;
            }
            else
            {
                var failedAttempts = card!=null? card.FailedLoginAttempts :0;
                card.FailedLoginAttempts = failedAttempts + 1;
                cardRepository.Update(card);

                if (card.FailedLoginAttempts >= 3)
                {
                    BlockFailedAttempts(cardNumber, card.FailedLoginAttempts);
                    Console.WriteLine("Your card has been blocked probobly cause your failed attempt by wrong pass.");
                }
                return false;
            }
        }


        public void ChangePassword(string cardNumber, string newPassword)
        {
            var card = cardRepository.Get(cardNumber);
            if (card != null)
            {
                card.Password = newPassword;
                cardRepository.Update(card);
            }
        }
        private bool DailyLimit(string cardNumber, float amount)
        {
            
            var todayTransfers = transactionRepository.GetTransactionsBy(cardNumber)
                .Where(t => t.TransactionDate.Date == DateTime.Today).Sum(t => t.Amount);

            
            return (todayTransfers + amount) > 250;
        }
        private float TransactionFee(float amount)
        {
            if (amount > 1000)
            {
                return amount * 0.015f;
            }
            else
            {
                
                return amount * 0.005f;
            }
        }
        public float GetCardBalance(string cardNumber)
        {
            var card = cardRepository.Get(cardNumber);
            if (card != null)
            {
                return card.Balance;
            }
            throw new Exception("Card not found.");
        }

        public void BlockFailedAttempts(string cardNumber, int failedAttempts)
        {
            if (failedAttempts >= 3)
            {
                var card = cardRepository.Get(cardNumber);
                if (card != null)
                {
                    card.IsActive = false;
                    cardRepository.Update(card);
                }
            }
        }

    }
}
