using System;
using System.IO;
using HW_Week15.Services;
using HW_Week15.Entities;
using HW_Week15.DAL.Repositories;

namespace HW_Week15
{
    public class Program
    {
        private static CardService cardService = new CardService();
        private static CardRepository cardRepository = new CardRepository();

       
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Banking System!");
            ShowMainMenu();
        }

        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Console.WriteLine("Thank you for using the system. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("Enter Card Number:");
            string cardNumber = Console.ReadLine();

            var card = cardRepository.Get(cardNumber);
            if (card != null && !card.IsActive)
            {
                Console.WriteLine("Your card is blocked by fail attempts.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            if (cardService.ValidatePassword(cardNumber, password))
            {
                Console.WriteLine("Login successful!");
                ShowUserMenu(cardNumber);
            }
            else
            {
                Console.WriteLine("Invalid card number or password.");
                if (card != null && !card.IsActive) 
                {
                    Console.WriteLine("Your card has been blocked due to multiple failed login attempts.");
                }
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        public static void ShowUserMenu(string cardNumber)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Menu:");
                Console.WriteLine("1. Transfer Money");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Change Password");
                Console.WriteLine("5. Logout");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TransferMoney(cardNumber);
                        break;
                    case "2":
                        ViewTransactions(cardNumber);
                        break;
                    case "3":
                        CheckBalance(cardNumber);
                        break;
                    case "4":
                        ChangePassword(cardNumber);
                        break;
                    case "5":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static void TransferMoney(string cardNumber)
        {
            FileGenerator generator = new FileGenerator();
            Console.Clear();
            Console.WriteLine("Transfer Money:");
            Console.WriteLine("Enter Destination Card Number:");
            string destinationCardNumber = Console.ReadLine();

            Console.WriteLine("Enter Transfer Amount:");
            float amount = float.Parse(Console.ReadLine());
            string code = generator.GenerateVerificationCode();
            Console.WriteLine($"Generated verification code: {code}");

          
            Console.Write(" Enter the dynamic password: ");
            string enteredCode = Console.ReadLine();
            
            bool isValid = generator.ValidateVerificationCode(enteredCode);

            if (isValid)
            {
                Console.WriteLine("The dynamic code is valid.");
            }
            else
            {
                Console.WriteLine("The dynamic code is invalid or expired.");
            }
            Console.WriteLine("Enter Password to confirm transaction:");
            string password = Console.ReadLine();

            if (cardService.ValidatePassword(cardNumber, password))
            {
                string result = cardService.Transfer(cardNumber, destinationCardNumber, amount);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid password.");
            }

            Console.WriteLine("Press any key to return to the user menu...");
            Console.ReadKey();
        }

        public static void ViewTransactions(string cardNumber)
        {
            Console.Clear();
            Console.WriteLine("Transaction History:");

            var transactions = cardService.GetTransactions(cardNumber);
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
            }
            else
            {
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"Transaction ID: {transaction.Id}, Amount: {transaction.Amount}, Date: {transaction.TransactionDate}, Success: {transaction.IsSuccessful}");
                }
            }

            Console.WriteLine("Press any key to return to the user menu...");
            Console.ReadKey();
        }

        public static void CheckBalance(string cardNumber)
        {
            Console.Clear();
            try
            {
                float balance = cardService.GetCardBalance(cardNumber);
                Console.WriteLine($"Your current balance is: {balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to return to the user menu...");
            Console.ReadKey();
        }

        public static void ChangePassword(string cardNumber)
        {
            Console.Clear();
            Console.WriteLine("Change Password:");

            Console.WriteLine("Enter New Password:");
            string newPassword = Console.ReadLine();

            cardService.ChangePassword(cardNumber, newPassword);
            Console.WriteLine("Password changed successfully!");

            Console.WriteLine("Press any key to return to the user menu...");
            Console.ReadKey();
        }
    }
}
