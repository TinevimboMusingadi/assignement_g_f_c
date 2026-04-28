using System;
using System.Windows.Forms;
using Assignment.Models;

namespace Assignment.Forms
{
    public partial class QuestionEForm : Form
    {
        private BankAccount account;

        public QuestionEForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                account = new BankAccount(txtOwner.Text, decimal.Parse(txtAmount.Text));
                RefreshDisplay();
                MessageBox.Show("Account created!");
                btnDeposit.Enabled = true;
                btnWithdraw.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                account.Deposit(decimal.Parse(txtAmount.Text));
                RefreshDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deposit failed: " + ex.Message);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                account.Withdraw(decimal.Parse(txtAmount.Text));
                RefreshDisplay();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Withdrawal failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RefreshDisplay()
        {
            if (account != null)
            {
                lblBalance.Text = $"Balance: {account.Balance:C}";
                lstTransactions.Items.Clear();
                foreach (string line in account.GetTransactions())
                    lstTransactions.Items.Add(line);
            }
        }
    }
}
