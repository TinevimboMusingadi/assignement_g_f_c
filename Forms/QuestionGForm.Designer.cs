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
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Event-Driven UI: Subject Scheduler";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            // lblCheckedHeader
            this.lblCheckedHeader.Location = new System.Drawing.Point(20, 50);
            this.lblCheckedHeader.Text = "1. Choose Subjects:";
            StyleConfig.ApplyLabelStyle(this.lblCheckedHeader);
            
            // checkedListBox1
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.Location = new System.Drawing.Point(20, 75);
            this.checkedListBox1.Size = new System.Drawing.Size(180, 120);
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);

            // lblDateHeader
            this.lblDateHeader.Location = new System.Drawing.Point(220, 50);
            this.lblDateHeader.Text = "2. Select Date:";
            StyleConfig.ApplyLabelStyle(this.lblDateHeader);

            // dateTimePicker1
            this.dateTimePicker1.Location = new System.Drawing.Point(220, 75);
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(220, 115);
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.Text = "Add to Schedule";
            StyleConfig.ApplyButtonStyle(this.btnAdd);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // treeView1
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Location = new System.Drawing.Point(440, 75);
            this.treeView1.Size = new System.Drawing.Size(240, 180);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);

            // linkLabel1
            this.linkLabel1.Location = new System.Drawing.Point(20, 210);
            this.linkLabel1.Size = new System.Drawing.Size(180, 20);
            this.linkLabel1.Text = "🌐 Explore .NET Documentation";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);

            // lblStatus
            this.lblStatus.BackColor = System.Drawing.Color.LightBlue;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Location = new System.Drawing.Point(20, 240);
            this.lblStatus.Size = new System.Drawing.Size(400, 25);
            this.lblStatus.Text = "Status: Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // QuestionGForm
            this.ClientSize = new System.Drawing.Size(700, 280);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCheckedHeader);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.lblDateHeader);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblStatus);
            this.Name = "QuestionGForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question G - Advanced Controls";
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
        private System.Windows.Forms.Label lblTitle;
    }
}
