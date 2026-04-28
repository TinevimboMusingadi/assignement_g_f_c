namespace Assignment.Forms
{
    partial class QuestionDForm
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
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.txtTest1 = new System.Windows.Forms.TextBox();
            this.txtTest2 = new System.Windows.Forms.TextBox();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblTest1 = new System.Windows.Forms.Label();
            this.lblTest2 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lstPassedStudents = new System.Windows.Forms.ListBox();
            this.lblPassedHeader = new System.Windows.Forms.Label();
            this.btnWhyException = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Labels and TextBoxes
            this.lblStudentName.Location = new System.Drawing.Point(20, 20);
            this.lblStudentName.Text = "Student Name:";
            this.txtStudentName.Location = new System.Drawing.Point(130, 20);
            this.txtStudentName.Size = new System.Drawing.Size(150, 23);

            this.lblTest1.Location = new System.Drawing.Point(20, 50);
            this.lblTest1.Text = "Test 1 Mark:";
            this.txtTest1.Location = new System.Drawing.Point(130, 50);
            this.txtTest1.Size = new System.Drawing.Size(150, 23);

            this.lblTest2.Location = new System.Drawing.Point(20, 80);
            this.lblTest2.Text = "Test 2 Mark:";
            this.txtTest2.Location = new System.Drawing.Point(130, 80);
            this.txtTest2.Size = new System.Drawing.Size(150, 23);

            // btnCalculate
            this.btnCalculate.Location = new System.Drawing.Point(20, 120);
            this.btnCalculate.Size = new System.Drawing.Size(100, 30);
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // lblAverage
            this.lblAverage.Location = new System.Drawing.Point(130, 120);
            this.lblAverage.Size = new System.Drawing.Size(150, 30);
            this.lblAverage.Text = "Average: -";
            this.lblAverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lstPassedStudents
            this.lblPassedHeader.Location = new System.Drawing.Point(300, 20);
            this.lblPassedHeader.Text = "Passed Students:";
            this.lstPassedStudents.Location = new System.Drawing.Point(300, 40);
            this.lstPassedStudents.Size = new System.Drawing.Size(150, 110);

            // btnWhyException
            this.btnWhyException.Location = new System.Drawing.Point(20, 170);
            this.btnWhyException.Size = new System.Drawing.Size(200, 30);
            this.btnWhyException.Text = "Why Exception Handling?";
            this.btnWhyException.Click += new System.EventHandler(this.btnWhyException_Click);

            // QuestionDForm
            this.ClientSize = new System.Drawing.Size(480, 220);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.lblTest1);
            this.Controls.Add(this.txtTest1);
            this.Controls.Add(this.lblTest2);
            this.Controls.Add(this.txtTest2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.lblPassedHeader);
            this.Controls.Add(this.lstPassedStudents);
            this.Controls.Add(this.btnWhyException);
            this.Name = "QuestionDForm";
            this.Text = "Question D - Students & Exceptions";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtTest1;
        private System.Windows.Forms.TextBox txtTest2;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblTest1;
        private System.Windows.Forms.Label lblTest2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.ListBox lstPassedStudents;
        private System.Windows.Forms.Label lblPassedHeader;
        private System.Windows.Forms.Button btnWhyException;
    }
}
