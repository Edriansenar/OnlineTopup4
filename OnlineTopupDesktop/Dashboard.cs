using OnlineTopupBusinessLogic;
using OnlineTopupDataService;
using OnlineTopupCommon;
using System;
using System.Text;
using System.Windows.Forms;

namespace OnlineTopupDesktop
{
    public partial class Dashboard : Form
    {
        // fields
        private UserAccount _loggedInUser;
        private Cart _cart;
        private ITopupDataService _dataService = new DBDataService();
        private string _selectedGame = "";

        // constructor
        public Dashboard(UserAccount user)
        {
            InitializeComponent();
            _loggedInUser = user;
            _cart = new Cart(_dataService, _loggedInUser.Id);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            comboBoxSelectAmount.Items.AddRange(new string[] { "50", "100", "500", "5,000", "10,000" });
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // optional
        }

        private void radioButtonMobileLegends_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMobileLegends.Checked)
                _selectedGame = "Mobile Legends";
        }

        private void radioButtonLeagueOfLegends_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLeagueOfLegends.Checked)
                _selectedGame = "League of Legends";
        }

        private void radioButtonTeamFightTactics_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTeamFightTactics.Checked)
                _selectedGame = "Teamfight Tactics";
        }

        private void radioButtonCallOfDuty_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCallOfDuty.Checked)
                _selectedGame = "Call of Duty Mobile";
        }

        private void radioButtonGCASH_CheckedChanged(object sender, EventArgs e)
        {
            // optional
        }

        private void radioButtonPayPal_CheckedChanged(object sender, EventArgs e)
        {
            // optional
        }

        private void comboBoxSelectAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // optional
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedGame))
            {
                MessageBox.Show("Please select a game first.");
                return;
            }

            if (comboBoxSelectAmount.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an amount.");
                return;
            }

            int amountIndex = comboBoxSelectAmount.SelectedIndex + 1;
            _cart.AddToCart(_selectedGame, amountIndex);

            MessageBox.Show("Item added to cart!");
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string paymentMethod = "";

            if (checkBoxGCASH.Checked)
                paymentMethod = "GCash";
            else if (checkBoxPayPal.Checked)
                paymentMethod = "PayPal";
            else
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            var data = _cart.GetCheckoutData(paymentMethod);
            _cart.ClearCart();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"User ID: {data.UserId}");
            sb.AppendLine($"Payment Method: {data.PaymentMethod}");
            sb.AppendLine("Items:");
            data.Items.ForEach(item => sb.AppendLine("- " + item));

            MessageBox.Show("Checkout Complete!\n\n" + sb.ToString(), "Checkout Summary");
        }


        private void checkBoxGCASH_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGCASH.Checked)
                checkBoxPayPal.Checked = false;
        }

        private void checkBoxPayPal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPayPal.Checked)
                checkBoxGCASH.Checked = false;
        }
    }
}

