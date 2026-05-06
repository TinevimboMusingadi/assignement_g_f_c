using System.Drawing;
using System.Windows.Forms;

namespace Assignment.Forms
{
    partial class SqlServer2022Form
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
            this.lblTitle = new Label();
            this.lblHint = new Label();
            this.lblServer = new Label();
            this.cmbServer = new ComboBox();
            this.dataGridView1 = new DataGridView();
            this.btnRefresh = new Button();
            this.btnSetup = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblTitle.Location = new Point(16, 12);
            this.lblTitle.Text = "Products (SQL Server)";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            this.lblHint.AutoSize = true;
            this.lblHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblHint.MaximumSize = new Size(720, 0);
            this.lblHint.Location = new Point(16, 40);
            this.lblHint.Text =
                "Error 26 usually means SQLEXPRESS is not installed. Try \".\" (default MSSQLSERVER) "
                + "first if you have SQL Developer/Full Edition. Env MSSQL_SERVER overrides default.";
            StyleConfig.ApplyLabelStyle(this.lblHint);

            this.lblServer.AutoSize = true;
            this.lblServer.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblServer.Location = new Point(16, 100);
            this.lblServer.Text = "Server instance (pick or type manually):";
            StyleConfig.ApplyLabelStyle(this.lblServer);

            this.cmbServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cmbServer.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbServer.Location = new Point(16, 124);
            this.cmbServer.Size = new Size(708, 23);
            this.cmbServer.TabIndex = 0;

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new Point(16, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new Size(708, 240);

            this.btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnRefresh.Location = new Point(468, 412);
            this.btnRefresh.Size = new Size(120, 36);
            this.btnRefresh.Text = "Refresh";
            StyleConfig.ApplyButtonStyle(this.btnRefresh);
            this.btnRefresh.Click += btnRefresh_Click;

            this.btnSetup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnSetup.Location = new Point(604, 412);
            this.btnSetup.Size = new Size(120, 36);
            this.btnSetup.Text = "Setup SQL DB";
            StyleConfig.ApplyButtonStyle(this.btnSetup);
            this.btnSetup.Click += btnSetup_Click;

            this.ClientSize = new Size(740, 466);
            this.MinimumSize = new Size(560, 380);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.cmbServer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSetup);
            this.Name = "SqlServer2022Form";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SQL Server 2022 — Products";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle;
        private Label lblHint;
        private Label lblServer;
        private ComboBox cmbServer;
        private DataGridView dataGridView1;
        private Button btnRefresh;
        private Button btnSetup;
    }
}
