namespace Assignment.Forms
{
    partial class QuestionGForm
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCheckedHeader = new System.Windows.Forms.Label();
            this.lblDateHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblCheckedHeader
            this.lblCheckedHeader.Location = new System.Drawing.Point(20, 20);
            this.lblCheckedHeader.Text = "Select Subjects:";
            // checkedListBox1
            this.checkedListBox1.Location = new System.Drawing.Point(20, 40);
            this.checkedListBox1.Size = new System.Drawing.Size(150, 100);
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);

            // lblDateHeader
            this.lblDateHeader.Location = new System.Drawing.Point(200, 20);
            this.lblDateHeader.Text = "Select Date:";
            // dateTimePicker1
            this.dateTimePicker1.Location = new System.Drawing.Point(200, 40);
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(200, 80);
            this.btnAdd.Size = new System.Drawing.Size(120, 30);
            this.btnAdd.Text = "Add to Schedule";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // treeView1
            this.treeView1.Location = new System.Drawing.Point(420, 40);
            this.treeView1.Size = new System.Drawing.Size(250, 150);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);

            // linkLabel1
            this.linkLabel1.Location = new System.Drawing.Point(20, 150);
            this.linkLabel1.Size = new System.Drawing.Size(150, 20);
            this.linkLabel1.Text = "Microsoft .NET Docs";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(20, 180);
            this.lblStatus.Size = new System.Drawing.Size(380, 20);
            this.lblStatus.Text = "Ready";

            // QuestionGForm
            this.ClientSize = new System.Drawing.Size(700, 220);
            this.Controls.Add(this.lblCheckedHeader);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.lblDateHeader);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblStatus);
            this.Name = "QuestionGForm";
            this.Text = "Question G - UI Controls";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCheckedHeader;
        private System.Windows.Forms.Label lblDateHeader;
    }
}
