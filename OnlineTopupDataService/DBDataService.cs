using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTopupCommon;
using OnlineTopupDataService;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;


namespace OnlineTopupDataService
{
    public class DBDataService : ITopupDataService
    {
        static List<UserAccount> userAccounts = new List<UserAccount>();
        static string connectionString
= "Data Source =YANN\\SQLEXPRESS02; Initial Catalog = AccountsDB; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;
        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void CreateAccount(UserAccount topupAccount)
        {
            var insertStatement = "INSERT INTO Accounts VALUES (@Username, @Password)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Username", topupAccount.User);
            insertCommand.Parameters.AddWithValue("@Password", topupAccount.Pass);

            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<UserAccount> GetAccounts()
        {
            string selectStatement = "SELECT Username, Password FROM Accounts";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var topupAccounts = new List<UserAccount>();

            while (reader.Read())
            {


                UserAccount topupAccount = new UserAccount();
                topupAccount.User = reader["Username"].ToString();
                topupAccount.Pass = reader["Password"].ToString();

                topupAccounts.Add(topupAccount);
            }

            sqlConnection.Close();
            return topupAccounts;

        }

        public void RemoveAccount(UserAccount topupAccount)
        {
            sqlConnection.Open();

            var deleteStatement = $"DELETE FROM Accounts WHERE Username = @Username";
            SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Username", topupAccount.User);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateAccount(UserAccount topupAccount)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE Accounts SET Username = @Username, Password = @Password";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Username", topupAccount.User);
            updateCommand.Parameters.AddWithValue("@Password", topupAccount.Pass);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public UserAccount GetAccountByUsername(string username)
        {
            var selectStatement = "SELECT Id, Username, Password FROM Accounts WHERE Username = @Username";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Username", username);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            UserAccount account = null;
            if (reader.Read())
            {
                account = new UserAccount
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    User = reader["Username"].ToString(),
                    Pass = reader["Password"].ToString()
                };
            }

            sqlConnection.Close();
            return account;
        }

        public bool ValidateAccount(string username, string password)
        {
            var selectStatement = "SELECT COUNT(*) FROM Accounts WHERE Username = @Username AND Password = @Password";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Username", username);
            selectCommand.Parameters.AddWithValue("@Password", password);

            sqlConnection.Open();
            int count = (int)selectCommand.ExecuteScalar();
            sqlConnection.Close();

            return count > 0;
        }

        public void AddCartItem(int userId, string gameName, string amount)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Cart (UserId, GameName, Amount) VALUES (@userId, @game, @amount)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@game", gameName);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.ExecuteNonQuery();
            }
        }

        public List<(string GameName, string Amount)> GetCartItems(int userId)
        {
            var items = new List<(string, string)>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT GameName, Amount FROM Cart WHERE UserId = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string game = reader.GetString(0);
                        string amount = reader.GetString(1);
                        items.Add((game, amount));
                    }
                }
            }

            return items;
        }

        public void ClearCart(int userId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Cart WHERE UserId = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveCartItem(int userId, int itemIndex)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();


                var cmd = new SqlCommand(@"DELETE FROM Cart WHERE Id IN (SELECT Id FROM (SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS RowNum FROM Cart WHERE UserId = @UserId) AS OrderedWHERE RowNum = @ItemIndex
            )", conn);

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ItemIndex", itemIndex);
                cmd.ExecuteNonQuery();
            }
        }



    }
}
