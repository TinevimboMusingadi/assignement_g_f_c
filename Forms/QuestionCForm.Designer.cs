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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(500, 200);

            // lblName, txtName
            this.lblName.Location = new System.Drawing.Point(20, 240);
            this.lblName.Size = new System.Drawing.Size(100, 20);
            this.lblName.Text = "Product Name:";
            this.txtName.Location = new System.Drawing.Point(130, 240);
            this.txtName.Size = new System.Drawing.Size(150, 23);

            // lblPrice, txtPrice
            this.lblPrice.Location = new System.Drawing.Point(20, 270);
            this.lblPrice.Size = new System.Drawing.Size(100, 20);
            this.lblPrice.Text = "Price:";
            this.txtPrice.Location = new System.Drawing.Point(130, 270);
            this.txtPrice.Size = new System.Drawing.Size(150, 23);

            // lblStock, txtStock
            this.lblStock.Location = new System.Drawing.Point(20, 300);
            this.lblStock.Size = new System.Drawing.Size(100, 20);
            this.lblStock.Text = "Stock:";
            this.txtStock.Location = new System.Drawing.Point(130, 300);
            this.txtStock.Size = new System.Drawing.Size(150, 23);

            // btnInsert
            this.btnInsert.Location = new System.Drawing.Point(300, 240);
            this.btnInsert.Size = new System.Drawing.Size(100, 30);
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(410, 240);
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(300, 280);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnLinq
            this.btnLinq.Location = new System.Drawing.Point(410, 280);
            this.btnLinq.Size = new System.Drawing.Size(100, 30);
            this.btnLinq.Text = "LINQ (>100)";
            this.btnLinq.Click += new System.EventHandler(this.btnLinq_Click);

            // btnLoad
            this.btnLoad.Location = new System.Drawing.Point(530, 20);
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.Text = "Load All";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // btnLinqAdvantages
            this.btnLinqAdvantages.Location = new System.Drawing.Point(530, 60);
            this.btnLinqAdvantages.Size = new System.Drawing.Size(100, 50);
            this.btnLinqAdvantages.Text = "LINQ Advantages";
            this.btnLinqAdvantages.Click += new System.EventHandler(this.btnLinqAdvantages_Click);

            // QuestionCForm
            this.ClientSize = new System.Drawing.Size(650, 350);
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
            this.Text = "Question C - SQL & LINQ";
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
    }
}
