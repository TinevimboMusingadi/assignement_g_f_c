using System.Drawing;
using System.Windows.Forms;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Student Performance Analysis";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            // Labels and TextBoxes
            this.lblStudentName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblStudentName.Location = new System.Drawing.Point(20, 50);
            this.lblStudentName.Text = "Student Name:";
            StyleConfig.ApplyLabelStyle(this.lblStudentName);
            this.txtStudentName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.txtStudentName.Location = new System.Drawing.Point(140, 50);
            this.txtStudentName.Size = new System.Drawing.Size(170, 23);

            this.lblTest1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblTest1.Location = new System.Drawing.Point(20, 85);
            this.lblTest1.Text = "Test 1 Score:";
            StyleConfig.ApplyLabelStyle(this.lblTest1);
            this.txtTest1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.txtTest1.Location = new System.Drawing.Point(140, 85);
            this.txtTest1.Size = new System.Drawing.Size(170, 23);

            this.lblTest2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblTest2.Location = new System.Drawing.Point(20, 120);
            this.lblTest2.Text = "Test 2 Score:";
            StyleConfig.ApplyLabelStyle(this.lblTest2);
            this.txtTest2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.txtTest2.Location = new System.Drawing.Point(140, 120);
            this.txtTest2.Size = new System.Drawing.Size(170, 23);

            // btnCalculate
            this.btnCalculate.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnCalculate.Location = new System.Drawing.Point(20, 158);
            this.btnCalculate.Size = new System.Drawing.Size(290, 42);
            this.btnCalculate.Text = "Calculate Result";
            StyleConfig.ApplyButtonStyle(this.btnCalculate);
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // lblAverage — dedicated row below button so DPI never clips numeric
            this.lblAverage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblAverage.AutoSize = true;
            this.lblAverage.Font = StyleConfig.HeaderFont;
            this.lblAverage.ForeColor = StyleConfig.PrimaryBlue;
            this.lblAverage.Location = new System.Drawing.Point(20, 210);
            this.lblAverage.Text = "Average: —";
            this.lblAverage.MaximumSize = new System.Drawing.Size(400, 0);

            // lstPassedStudents
            this.lblPassedHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblPassedHeader.Location = new System.Drawing.Point(336, 50);
            this.lblPassedHeader.Text = "Passed Students Log:";
            StyleConfig.ApplyLabelStyle(this.lblPassedHeader, true);
            this.lstPassedStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.lstPassedStudents.BorderStyle = BorderStyle.FixedSingle;
            this.lstPassedStudents.Location = new System.Drawing.Point(336, 80);
            this.lstPassedStudents.Size = new System.Drawing.Size(264, 195);

            // btnWhyException
            this.btnWhyException.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.btnWhyException.Location = new System.Drawing.Point(20, 297);
            this.btnWhyException.Size = new System.Drawing.Size(580, 42);
            this.btnWhyException.Text = "Importance of Exception Handling";
            StyleConfig.ApplyButtonStyle(this.btnWhyException, false);
            this.btnWhyException.Click += new System.EventHandler(this.btnWhyException_Click);

            // QuestionDForm
            this.ClientSize = new System.Drawing.Size(620, 356);
            this.MinimumSize = new System.Drawing.Size(520, 320);
            this.Controls.Add(this.lblTitle);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question D - Student Grading";
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
        private System.Windows.Forms.Label lblTitle;
    }
}
