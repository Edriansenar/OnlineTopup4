using System;
using System.Collections.Generic;

namespace OnlineTopup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Welcome to Online Game Topup");
            Console.WriteLine("-----------------------------------");

            string userAccount = string.Empty;
            string userPass = string.Empty;
            OnlineTopupDataService dataService = new OnlineTopupDataService();


            do
            {
                Console.Write("Enter Username: ");
                userAccount = Console.ReadLine();

                Console.Write("Enter Password: ");
                userPass = Console.ReadLine();

                if (!dataService.ValidateTopupAccount(userAccount, userPass))
                {
                    Console.WriteLine("FAILED: Incorrect Username or Password. Please try again");
                }

            } while (!dataService.ValidateTopupAccount(userAccount, userPass));

            List<string> cart = new List<string>();

            while (true)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Welcome {userAccount}, Let's Proceed to Online Topup");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("");

                DisplayTopup();

                Console.Write("Enter top-up option: ");
                int userChoice = Convert.ToInt16(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        cart.Add(PromptTopupAmount("Mobile Legends"));
                        break;
                    case 2:
                        cart.Add(PromptTopupAmount("League Of Legends"));
                        break;
                    case 3:
                        cart.Add(PromptTopupAmount("Honor Of Kings"));
                        break;
                    case 4:
                        cart.Add(PromptTopupAmount("Call of Duty Mobile"));
                        break;
                    case 5:
                        cart.Add(PromptTopupAmount("Teamfight Tactics"));
                        break;
                    case 6:
                        Console.WriteLine("Logout...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                if (cart.Count > 0)
                {
                    ManageCart(cart);
                }
            }
        }

        static void DisplayTopup()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("What game would you like to top-up?");
            Console.WriteLine("-------------------------------");

            string[] choices = new string[] { "[1] Mobile Legends", "[2] League Of Legends", "[3] Honor of Kings", "[4] Call of Duty", "[5] Teamfight Tactics", "[6] Logout." };

            Console.WriteLine("TOP-UP:");
            foreach (var topup in choices)
            {
                Console.WriteLine(topup);
            }
        }

        static void ManageCart(List<string> cart)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Your Cart:");
            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Would you like to:");
            Console.WriteLine("[1] Remove an item from the cart.");
            Console.WriteLine("[2] Proceed to checkout.");
            Console.WriteLine("[3] Continue shopping.");
            Console.WriteLine("[4] Exit.");
            Console.WriteLine("-----------------------------------");

            int actionChoice = Convert.ToInt16(Console.ReadLine());

            switch (actionChoice)
            {
                case 1:
                    RemoveFromCart(cart);
                    break;
                case 2:
                    Checkout(cart);
                    return;
                case 3:
                    return;
                case 4:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Returning to shopping...");
                    break;
            }
        }

        static void RemoveFromCart(List<string> cart)
        {
            Console.WriteLine("Enter the number of the item you want to remove:");

            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {cart[i]}");
            }

            int removeChoice = Convert.ToInt16(Console.ReadLine()) - 1;
            if (removeChoice >= 0 && removeChoice < cart.Count)
            {
                cart = OnlineTopupBusinessLogic.RemoveFromCart(removeChoice, cart);
                Console.WriteLine("Item removed from the cart.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void Checkout(List<string> cart)
        {
            Console.WriteLine("Proceeding to checkout...");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Please select a payment method:");

            string[] paymentOptions = new string[]
            {
             "[1] GCash",
             "[2] PayMaya",
             "[3] Credit Card",
             "[4] Debit Card",
             "[5] GrabPay"
            };

            foreach (string option in paymentOptions)
            {
                Console.WriteLine(option);
            }

            int paymentChoice = 0;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out paymentChoice) && paymentChoice >= 1 && paymentChoice <= paymentOptions.Length)
                {
                    Console.Write($"Thanks for purchasing !");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid payment option.");
                }
            }

            string selectedPayment = paymentOptions[paymentChoice - 1].Substring(4);

            string checkoutMessage = OnlineTopupBusinessLogic.ProcessCheckout(cart, 1, selectedPayment);
        }
        static string PromptTopupAmount(string gameName)
        {
            Console.WriteLine($"How much would you like to top up for {gameName}?");
            string[] amounts = { "50", "100", "200", "500", "1000" };

            for (int i = 0; i < amounts.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {amounts[i]}");
            }

            int amountChoice = 0;
            while (true)
            {
                Console.Write("Enter amount option: ");
                if (int.TryParse(Console.ReadLine(), out amountChoice) && amountChoice >= 1 && amountChoice <= amounts.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid amount.");
                }
            }

            return $"{gameName}: {amounts[amountChoice - 1]}";
        }

    }
}


