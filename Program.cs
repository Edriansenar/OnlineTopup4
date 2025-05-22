using System;
using System.Collections.Generic;
using TopupDataService;
using OnlineTopupBusinessLogic;
using OnlineTopupBusinessLogic.OnlineTopupBusinessLogic;
using OnlineTopupDataService;

namespace OnlineTopup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Welcome to Online Game Topup");
            Console.WriteLine("-----------------------------------");

            ITopupDataService dataService = new JsonFileDataService();
            TopupService topupService = new TopupService(dataService);
            string user = string.Empty;
            string pass = string.Empty;
            bool authenticated = false;

            while (!authenticated)
            {
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Register");
                Console.WriteLine("[3] Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter Username: ");
                        user = Console.ReadLine();

                        Console.Write("Enter Password: ");
                        pass = Console.ReadLine();

                        if (topupService.ValidateAccount(user, pass))
                        {
                            Console.WriteLine("Login successful!");
                            authenticated = true;
                        }
                        else
                        {
                            Console.WriteLine("FAILED: Incorrect Username or Password. Please try again.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter new Username: ");
                        string newUser = Console.ReadLine();

                        Console.Write("Enter new Password: ");
                        string newPass = Console.ReadLine();

                        var existingUser = topupService.GetAccountByUsername(newUser);
                        if (existingUser != null)
                        {
                            Console.WriteLine("Username already exists. Try another.");
                        }
                        else
                        {
                            topupService.CreateAccount(new OnlineTopupCommon.UserAccount
                            {
                                User = newUser,
                                Pass = newPass
                            });

                            Console.WriteLine("Account created successfully. You can now login.");
                        }
                        break;


                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }


            Cart cart = new Cart();

            while (true)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Welcome {user}, Let's Proceed to Online Topup");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("");

                DisplayTopupOptions();

                Console.Write("Enter top-up option: ");
                int userChoice = Convert.ToInt16(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        cart.AddToCart("Mobile Legends", PromptTopupAmountIndex("Mobile Legends"));
                        break;
                    case 2:
                        cart.AddToCart("League Of Legends", PromptTopupAmountIndex("League Of Legends"));
                        break;
                    case 3:
                        cart.AddToCart("Honor Of Kings", PromptTopupAmountIndex("Honor Of Kings"));
                        break;
                    case 4:
                        cart.AddToCart("Call of Duty Mobile", PromptTopupAmountIndex("Call of Duty Mobile"));
                        break;
                    case 5:
                        cart.AddToCart("Teamfight Tactics", PromptTopupAmountIndex("Teamfight Tactics"));
                        break;
                    case 6:
                        Console.WriteLine("Logout...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                if (cart.GetItems().Count > 0)
                {
                    ManageCart(cart);
                }
            }
        }

        static void DisplayTopupOptions()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("What game would you like to top-up?");
            Console.WriteLine("-------------------------------");

            string[] options = {
                "[1] Mobile Legends",
                "[2] League Of Legends",
                "[3] Honor of Kings",
                "[4] Call of Duty Mobile",
                "[5] Teamfight Tactics",
                "[6] Logout"
            };

            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
        }

        static int PromptTopupAmountIndex(string gameName)
        {
            Console.WriteLine($"How much would you like to top up for {gameName}?");
            string[] amounts = { "50", "100", "500", "5,000", "10,000" };

            for (int i = 0; i < amounts.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {amounts[i]}");
            }

            int amountChoice = 0;
            while (true)
            {
                Console.Write("Enter amount option: ");
                if (int.TryParse(Console.ReadLine(), out amountChoice) &&
                    amountChoice >= 1 && amountChoice <= amounts.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid amount.");
                }
            }

            return amountChoice;
        }

        static void ManageCart(Cart cart)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Your Cart:");
            List<string> items = cart.GetItems();

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {items[i]}");
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Options:");
            Console.WriteLine("[1] Remove an item");
            Console.WriteLine("[2] Proceed to checkout");
            Console.WriteLine("[3] Continue shopping");
            Console.WriteLine("[4] Exit");

            Console.Write("Choose an action: ");
            if (!int.TryParse(Console.ReadLine(), out int actionChoice))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            switch (actionChoice)
            {
                case 1:
                    Console.Write("Enter the number of the item to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int indexToRemove))
                    {
                        cart.RemoveFromCart(indexToRemove - 1);
                        Console.WriteLine("Item removed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                    break;

                case 2:
                    Checkout(cart);
                    break;

                case 3:
                    return;

                case 4:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void Checkout(Cart cart)
        {
            Console.WriteLine("Proceeding to checkout...");
            Console.WriteLine("Select a payment method:");

            string[] payments = {
                "[1] GCash",
                "[2] PayMaya",
                "[3] Credit Card",
                "[4] Debit Card",
                "[5] GrabPay"
            };

            foreach (string payment in payments)
            {
                Console.WriteLine(payment);
            }

            string selectedPayment = "Unknown";
            while (true)
            {
                Console.Write("Enter choice: ");
                if (int.TryParse(Console.ReadLine(), out int paymentChoice) &&
                    paymentChoice >= 1 && paymentChoice <= payments.Length)
                {
                    selectedPayment = payments[paymentChoice - 1].Substring(4);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid payment choice.");
                }
            }

            string result = cart.ProcessCheckout(1, selectedPayment);
            Console.WriteLine(result);
        }
    }
}