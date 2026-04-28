namespace Assignment.Forms
{
    partial class QuestionEForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lstTransactions = new System.Windows.Forms.ListBox();
            this.lblTransHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblOwner, txtOwner
            this.lblOwner.Location = new System.Drawing.Point(20, 20);
            this.lblOwner.Text = "Account Owner:";
            this.txtOwner.Location = new System.Drawing.Point(130, 20);
            this.txtOwner.Size = new System.Drawing.Size(150, 23);

            // lblAmount, txtAmount
            this.lblAmount.Location = new System.Drawing.Point(20, 50);
            this.lblAmount.Text = "Amount:";
            this.txtAmount.Location = new System.Drawing.Point(130, 50);
            this.txtAmount.Size = new System.Drawing.Size(150, 23);

            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(20, 90);
            this.btnCreate.Size = new System.Drawing.Size(100, 30);
            this.btnCreate.Text = "Create Account";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // btnDeposit
            this.btnDeposit.Enabled = false;
            this.btnDeposit.Location = new System.Drawing.Point(130, 90);
            this.btnDeposit.Size = new System.Drawing.Size(75, 30);
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);

            // btnWithdraw
            this.btnWithdraw.Enabled = false;
            this.btnWithdraw.Location = new System.Drawing.Point(210, 90);
            this.btnWithdraw.Size = new System.Drawing.Size(75, 30);
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);

            // lblBalance
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(20, 130);
            this.lblBalance.Size = new System.Drawing.Size(260, 30);
            this.lblBalance.Text = "Balance: $0.00";

            // lstTransactions
            this.lblTransHeader.Location = new System.Drawing.Point(300, 20);
            this.lblTransHeader.Text = "Transaction History:";
            this.lstTransactions.Location = new System.Drawing.Point(300, 40);
            this.lstTransactions.Size = new System.Drawing.Size(350, 120);

            // QuestionEForm
            this.ClientSize = new System.Drawing.Size(680, 180);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblTransHeader);
            this.Controls.Add(this.lstTransactions);
            this.Name = "QuestionEForm";
            this.Text = "Question E - Bank Account Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.ListBox lstTransactions;
        private System.Windows.Forms.Label lblTransHeader;
    }
}
