using System.Drawing;
using System.Windows.Forms;

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
            this.btnSetupDb = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Product Inventory Management (MySQL & LINQ)";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            // dataGridView1 — anchored with margin for sidebar (right) + input strip (bottom)
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 50);
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(586, 230);

            // lblName, txtName
            this.lblName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 345);
            this.lblName.MaximumSize = new System.Drawing.Size(130, 0);
            this.lblName.Text = "Product Name:";
            StyleConfig.ApplyLabelStyle(this.lblName);
            this.txtName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(150, 341);
            this.txtName.Size = new System.Drawing.Size(160, 23);

            // lblPrice, txtPrice
            this.lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 378);
            this.lblPrice.Text = "Price ($):";
            StyleConfig.ApplyLabelStyle(this.lblPrice);
            this.txtPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.txtPrice.Location = new System.Drawing.Point(150, 374);
            this.txtPrice.Size = new System.Drawing.Size(160, 23);

            // lblStock, txtStock
            this.lblStock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(20, 408);
            this.lblStock.Text = "Stock Level:";
            StyleConfig.ApplyLabelStyle(this.lblStock);
            this.txtStock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.txtStock.Location = new System.Drawing.Point(150, 404);
            this.txtStock.Size = new System.Drawing.Size(160, 23);

            // Action Buttons
            this.btnInsert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnInsert.Location = new System.Drawing.Point(332, 330);
            this.btnInsert.Size = new System.Drawing.Size(118, 36);
            this.btnInsert.Text = "Add Product";
            StyleConfig.ApplyButtonStyle(this.btnInsert);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);

            this.btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnUpdate.Location = new System.Drawing.Point(458, 330);
            this.btnUpdate.Size = new System.Drawing.Size(118, 36);
            this.btnUpdate.Text = "Update Price";
            StyleConfig.ApplyButtonStyle(this.btnUpdate);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnDelete.Location = new System.Drawing.Point(332, 374);
            this.btnDelete.Size = new System.Drawing.Size(118, 36);
            this.btnDelete.Text = "Remove";
            StyleConfig.ApplyButtonStyle(this.btnDelete, true);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnLinq.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnLinq.Location = new System.Drawing.Point(458, 374);
            this.btnLinq.Size = new System.Drawing.Size(118, 36);
            this.btnLinq.Text = "LINQ Analyze";
            StyleConfig.ApplyButtonStyle(this.btnLinq);
            this.btnLinq.Click += new System.EventHandler(this.btnLinq_Click);

            // Sidebar Buttons (right column)
            this.btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnLoad.Location = new System.Drawing.Point(624, 50);
            this.btnLoad.Size = new System.Drawing.Size(140, 42);
            this.btnLoad.Text = "Refresh Data";
            StyleConfig.ApplyButtonStyle(this.btnLoad);
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.btnLinqAdvantages.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnLinqAdvantages.Location = new System.Drawing.Point(624, 100);
            this.btnLinqAdvantages.Size = new System.Drawing.Size(140, 48);
            this.btnLinqAdvantages.Text = "Why LINQ?";
            StyleConfig.ApplyButtonStyle(this.btnLinqAdvantages, false);
            this.btnLinqAdvantages.Click += new System.EventHandler(this.btnLinqAdvantages_Click);

            // btnSetupDb
            this.btnSetupDb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSetupDb.Location = new System.Drawing.Point(624, 156);
            this.btnSetupDb.Size = new System.Drawing.Size(140, 42);
            this.btnSetupDb.Text = "Setup DB";
            StyleConfig.ApplyButtonStyle(this.btnSetupDb);
            this.btnSetupDb.Click += new System.EventHandler(this.btnSetupDb_Click);

            // QuestionCForm
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.MinimumSize = new System.Drawing.Size(640, 400);
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
            this.Controls.Add(this.btnSetupDb);
            this.Name = "QuestionCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question C - MySQL & LINQ";
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
        private System.Windows.Forms.Button btnSetupDb;
        private System.Windows.Forms.Label lblTitle;
    }
}
