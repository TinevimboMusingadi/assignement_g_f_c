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
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Banking System - Account Operations";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            // lblOwner, txtOwner
            this.lblOwner.Location = new System.Drawing.Point(20, 50);
            this.lblOwner.Text = "Account Holder:";
            StyleConfig.ApplyLabelStyle(this.lblOwner);
            this.txtOwner.Location = new System.Drawing.Point(140, 50);
            this.txtOwner.Size = new System.Drawing.Size(180, 23);

            // lblAmount, txtAmount
            this.lblAmount.Location = new System.Drawing.Point(20, 85);
            this.lblAmount.Text = "Amount ($):";
            StyleConfig.ApplyLabelStyle(this.lblAmount);
            this.txtAmount.Location = new System.Drawing.Point(140, 85);
            this.txtAmount.Size = new System.Drawing.Size(180, 23);

            // Action Buttons
            this.btnCreate.Location = new System.Drawing.Point(20, 125);
            this.btnCreate.Size = new System.Drawing.Size(140, 40);
            this.btnCreate.Text = "Open Account";
            StyleConfig.ApplyButtonStyle(this.btnCreate);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            this.btnDeposit.Enabled = false;
            this.btnDeposit.Location = new System.Drawing.Point(170, 125);
            this.btnDeposit.Size = new System.Drawing.Size(70, 40);
            this.btnDeposit.Text = "Deposit";
            StyleConfig.ApplyButtonStyle(this.btnDeposit);
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);

            this.btnWithdraw.Enabled = false;
            this.btnWithdraw.Location = new System.Drawing.Point(250, 125);
            this.btnWithdraw.Size = new System.Drawing.Size(70, 40);
            this.btnWithdraw.Text = "Withdraw";
            StyleConfig.ApplyButtonStyle(this.btnWithdraw);
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);

            // lblBalance
            this.lblBalance.BackColor = System.Drawing.Color.FromArgb(16, 24, 48);
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(0, 255, 128);
            this.lblBalance.Location = new System.Drawing.Point(20, 180);
            this.lblBalance.Size = new System.Drawing.Size(300, 50);
            this.lblBalance.Text = "Balance: $0.00";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lstTransactions
            this.lblTransHeader.Location = new System.Drawing.Point(340, 50);
            this.lblTransHeader.Text = "Recent Transactions:";
            StyleConfig.ApplyLabelStyle(this.lblTransHeader, true);
            this.lstTransactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransactions.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstTransactions.Location = new System.Drawing.Point(340, 80);
            this.lstTransactions.Size = new System.Drawing.Size(340, 150);

            // QuestionEForm
            this.ClientSize = new System.Drawing.Size(700, 260);
            this.Controls.Add(this.lblTitle);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question E - Bank Account";
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
        private System.Windows.Forms.Label lblTitle;
    }
}
