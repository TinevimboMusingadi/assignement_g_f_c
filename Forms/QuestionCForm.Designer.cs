namespace Assignment.Forms
{
    partial class QuestionCForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLinq = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLinqAdvantages = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Product Inventory Management (SQL & LINQ)";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            // dataGridView1
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(520, 180);

            // lblName, txtName
            this.lblName.Location = new System.Drawing.Point(20, 250);
            this.lblName.Size = new System.Drawing.Size(120, 20);
            this.lblName.Text = "Product Name:";
            StyleConfig.ApplyLabelStyle(this.lblName);
            this.txtName.Location = new System.Drawing.Point(140, 250);
            this.txtName.Size = new System.Drawing.Size(150, 23);

            // lblPrice, txtPrice
            this.lblPrice.Location = new System.Drawing.Point(20, 280);
            this.lblPrice.Size = new System.Drawing.Size(120, 20);
            this.lblPrice.Text = "Price ($):";
            StyleConfig.ApplyLabelStyle(this.lblPrice);
            this.txtPrice.Location = new System.Drawing.Point(140, 280);
            this.txtPrice.Size = new System.Drawing.Size(150, 23);

            // lblStock, txtStock
            this.lblStock.Location = new System.Drawing.Point(20, 310);
            this.lblStock.Size = new System.Drawing.Size(120, 20);
            this.lblStock.Text = "Stock Level:";
            StyleConfig.ApplyLabelStyle(this.lblStock);
            this.txtStock.Location = new System.Drawing.Point(140, 310);
            this.txtStock.Size = new System.Drawing.Size(150, 23);

            // Action Buttons
            this.btnInsert.Location = new System.Drawing.Point(310, 250);
            this.btnInsert.Size = new System.Drawing.Size(110, 35);
            this.btnInsert.Text = "Add Product";
            StyleConfig.ApplyButtonStyle(this.btnInsert);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);

            this.btnUpdate.Location = new System.Drawing.Point(430, 250);
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.Text = "Update Price";
            StyleConfig.ApplyButtonStyle(this.btnUpdate);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(310, 300);
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.Text = "Remove";
            StyleConfig.ApplyButtonStyle(this.btnDelete, false);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnLinq.Location = new System.Drawing.Point(430, 300);
            this.btnLinq.Size = new System.Drawing.Size(110, 35);
            this.btnLinq.Text = "LINQ Analyze";
            StyleConfig.ApplyButtonStyle(this.btnLinq);
            this.btnLinq.Click += new System.EventHandler(this.btnLinq_Click);

            // Sidebar Buttons
            this.btnLoad.Location = new System.Drawing.Point(550, 50);
            this.btnLoad.Size = new System.Drawing.Size(120, 40);
            this.btnLoad.Text = "Refresh Data";
            StyleConfig.ApplyButtonStyle(this.btnLoad);
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.btnLinqAdvantages.Location = new System.Drawing.Point(550, 100);
            this.btnLinqAdvantages.Size = new System.Drawing.Size(120, 50);
            this.btnLinqAdvantages.Text = "Why LINQ?";
            StyleConfig.ApplyButtonStyle(this.btnLinqAdvantages, false);
            this.btnLinqAdvantages.Click += new System.EventHandler(this.btnLinqAdvantages_Click);

            // QuestionCForm
            this.ClientSize = new System.Drawing.Size(690, 360);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnLinq);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnLinqAdvantages);
            this.Name = "QuestionCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question C - Database Operations";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLinq;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLinqAdvantages;
        private System.Windows.Forms.Label lblTitle;
    }
}
