namespace Assignment
{
    partial class Form1
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
            this.btnQuestionA = new System.Windows.Forms.Button();
            this.btnQuestionB = new System.Windows.Forms.Button();
            this.btnQuestionC = new System.Windows.Forms.Button();
            this.btnQuestionD = new System.Windows.Forms.Button();
            this.btnQuestionE = new System.Windows.Forms.Button();
            this.btnQuestionF = new System.Windows.Forms.Button();
            this.btnQuestionG = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.Text = "Visual Programming Assignment 2";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnQuestionA
            this.btnQuestionA.Location = new System.Drawing.Point(50, 80);
            this.btnQuestionA.Size = new System.Drawing.Size(150, 40);
            this.btnQuestionA.Text = "Question A - Arrays";
            this.btnQuestionA.Click += new System.EventHandler(this.btnQuestionA_Click);

            // btnQuestionB
            this.btnQuestionB.Location = new System.Drawing.Point(240, 80);
            this.btnQuestionB.Size = new System.Drawing.Size(150, 40);
            this.btnQuestionB.Text = "Question B - Loops";
            this.btnQuestionB.Click += new System.EventHandler(this.btnQuestionB_Click);

            // btnQuestionC
            this.btnQuestionC.Location = new System.Drawing.Point(50, 140);
            this.btnQuestionC.Size = new System.Drawing.Size(150, 40);
            this.btnQuestionC.Text = "Question C - SQL/LINQ";
            this.btnQuestionC.Click += new System.EventHandler(this.btnQuestionC_Click);

            // btnQuestionD
            this.btnQuestionD.Location = new System.Drawing.Point(240, 140);
            this.btnQuestionD.Size = new System.Drawing.Size(150, 40);
            this.btnQuestionD.Text = "Question D - Student";
            this.btnQuestionD.Click += new System.EventHandler(this.btnQuestionD_Click);

            // btnQuestionE
            this.btnQuestionE.Location = new System.Drawing.Point(50, 200);
            this.btnQuestionE.Size = new System.Drawing.Size(150, 40);
            this.btnQuestionE.Text = "Question E - Bank";
            this.btnQuestionE.Click += new System.EventHandler(this.btnQuestionE_Click);

            // btnQuestionF
            this.btnQuestionF.Location = new System.Drawing.Point(240, 200);
            this.btnQuestionF.Size = new System.Drawing.Size(150, 40);
            this.btnQuestionF.Text = "Question F - Power";
            this.btnQuestionF.Click += new System.EventHandler(this.btnQuestionF_Click);

            // btnQuestionG
            this.btnQuestionG.Location = new System.Drawing.Point(50, 260);
            this.btnQuestionG.Size = new System.Drawing.Size(340, 40);
            this.btnQuestionG.Text = "Question G - UI Controls";
            this.btnQuestionG.Click += new System.EventHandler(this.btnQuestionG_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(440, 330);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnQuestionA);
            this.Controls.Add(this.btnQuestionB);
            this.Controls.Add(this.btnQuestionC);
            this.Controls.Add(this.btnQuestionD);
            this.Controls.Add(this.btnQuestionE);
            this.Controls.Add(this.btnQuestionF);
            this.Controls.Add(this.btnQuestionG);
            this.Name = "Form1";
            this.Text = "Assignment Dashboard";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnQuestionA;
        private System.Windows.Forms.Button btnQuestionB;
        private System.Windows.Forms.Button btnQuestionC;
        private System.Windows.Forms.Button btnQuestionD;
        private System.Windows.Forms.Button btnQuestionE;
        private System.Windows.Forms.Button btnQuestionF;
        private System.Windows.Forms.Button btnQuestionG;
        private System.Windows.Forms.Label lblTitle;
    }
}
