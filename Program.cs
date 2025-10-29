using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OnlineTopup.OnlineTopupBusinessLogic;
using OnlineTopup.OnlineTopupCommon;
using OnlineTopupBusinessLogic;
using OnlineTopupBusinessLogic.OnlineTopupBusinessLogic;
using OnlineTopupCommon;
using OnlineTopupDataService;
using System;

namespace OnlineTopup
{
    internal class Program
    {
        // Configuration loaded once for the whole program
        static IConfiguration configuration;

        static void Main(string[] args)
        {
            // Load appsettings.json from output folder
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Welcome to Online Game Topup");
            Console.WriteLine("-------------------------------\n");

            ITopupDataService dataService = new JsonFileDataService();
            var topupService = new TopupService(dataService);
            UserAccount user = null;
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
                        Console.Write("Username: ");
                        string loginUser = Console.ReadLine();
                        Console.Write("Password: ");
                        string loginPass = Console.ReadLine();

                        if (topupService.ValidateAccount(loginUser, loginPass))
                        {
                            user = topupService.GetAccountByUsername(loginUser);
                            Console.WriteLine("Login successful!\n");
                            authenticated = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials.\n");
                        }
                        break;

                    case "2":
                        Console.Write("New Username: ");
                        string newUser = Console.ReadLine();
                        Console.Write("New Password: ");
                        string newPass = Console.ReadLine();

                        if (topupService.GetAccountByUsername(newUser) != null)
                        {
                            Console.WriteLine("Username already exists.\n");
                        }
                        else
                        {
                            topupService.CreateAccount(new UserAccount { User = newUser, Pass = newPass });
                            Console.WriteLine("Account created successfully.\n");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }

            Cart cart = new Cart(dataService, user.Id);

            while (true)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Choose a game to top up:");
                Console.WriteLine("[1] Mobile Legends");
                Console.WriteLine("[2] League of Legends");
                Console.WriteLine("[3] Honor of Kings");
                Console.WriteLine("[4] Call of Duty Mobile");
                Console.WriteLine("[5] Teamfight Tactics");
                Console.WriteLine("[6] Logout");

                Console.Write("Choice: ");
                if (!int.TryParse(Console.ReadLine(), out int gameChoice)) continue;

                string selectedGame = gameChoice switch
                {
                    1 => "Mobile Legends",
                    2 => "League of Legends",
                    3 => "Honor of Kings",
                    4 => "Call of Duty Mobile",
                    5 => "Teamfight Tactics",
                    6 => "",
                    _ => null
                };

                if (selectedGame == null)
                {
                    Console.WriteLine("Invalid option.\n");
                    continue;
                }
                if (gameChoice == 6) break;

                int amountIndex = PromptTopupAmountIndex(selectedGame);
                cart.AddToCart(selectedGame, amountIndex);

                ManageCart(cart);
            }
        }

        static int PromptTopupAmountIndex(string gameName)
        {
            string[] options = { "50", "100", "500", "5,000", "10,000" };

            Console.WriteLine($"How much would you like to top up for {gameName}?");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {options[i]}");
            }

            while (true)
            {
                Console.Write("Enter option: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= options.Length)
                    return choice;

                Console.WriteLine("Invalid input. Try again.");
            }
        }

        static void ManageCart(Cart cart)
        {
            Console.WriteLine("\nYour Cart:");
            var items = cart.GetItems();

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {items[i]}");
            }

            Console.WriteLine("\n[1] Remove item\n[2] Checkout\n[3] Continue shopping\n[4] Exit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int action)) return;

            switch (action)
            {
                case 1:
                    Console.Write("Enter item number to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        cart.RemoveFromCart(index - 1);
                        Console.WriteLine("Item removed.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.\n");
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
                    Console.WriteLine("Invalid option.\n");
                    break;
            }
        }

        static void Checkout(Cart cart)
        {
            Console.WriteLine("Select a payment method:");
            string[] methods = { "GCash", "PayMaya", "Credit Card", "Debit Card", "GrabPay" };

            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {methods[i]}");
            }

            string selected = null;
            while (true)
            {
                Console.Write("Enter choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= methods.Length)
                {
                    selected = methods[choice - 1];
                    break;
                }
                Console.WriteLine("Invalid input.\n");
            }

            var data = cart.GetCheckoutData(selected);
            Console.WriteLine("\nCheckout Complete!");
            Console.WriteLine($"User ID: {data.UserId}");
            Console.WriteLine($"Payment Method: {data.PaymentMethod}");
            Console.WriteLine("Items:");
            data.Items.ForEach(item => Console.WriteLine("- " + item));

            // --- Create EmailService with IOptions<EmailSettings> ---
            var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
            var options = Options.Create(emailSettings);
            var emailService = new EmailService(options);

            try
            {
                // EmailService.SendEmail currently expects accountNumber only
                emailService.SendEmail(data.UserId.ToString());
                Console.WriteLine("\n✅ Email confirmation sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n⚠️ Failed to send email: {ex.Message}");
            }

            cart.ClearCart();
        }
    }
}

