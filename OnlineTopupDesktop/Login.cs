using OnlineTopupBusinessLogic;
using OnlineTopupDataService;
using OnlineTopupCommon;
using System;
using System.Windows.Forms;
using OnlineTopupBusinessLogic.OnlineTopupBusinessLogic;

namespace OnlineTopupDesktop
{
    public partial class Login : Form
    {
        private ITopupDataService _dataService = new DBDataService();
        private TopupService _topupService;

        public Login()
        {
            InitializeComponent();
            _topupService = new TopupService(_dataService);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtBoxUsername.Text.Trim();
            string password = txtBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (_topupService.ValidateAccount(username, password))
            {
                var user = _topupService.GetAccountByUsername(username);
                MessageBox.Show("Login successful!");

                Dashboard dashboard = new Dashboard(user);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtBoxUsername.Text.Trim();
            string password = txtBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password to register.");
                return;
            }

            if (_topupService.GetAccountByUsername(username) != null)
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            var newUser = new UserAccount
            {
                User = username,
                Pass = password
            };
            _topupService.CreateAccount(newUser);
            MessageBox.Show("Account created successfully. You can now log in.");
        }

        private void txtBoxUsername_TextChanged(object sender, EventArgs e)
        {
            // optional
        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            // optional
        }
    }
}
