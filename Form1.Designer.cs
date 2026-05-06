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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuestionA = new System.Windows.Forms.Button();
            this.btnQuestionB = new System.Windows.Forms.Button();
            this.btnQuestionC = new System.Windows.Forms.Button();
            this.btnQuestionD = new System.Windows.Forms.Button();
            this.btnQuestionE = new System.Windows.Forms.Button();
            this.btnQuestionF = new System.Windows.Forms.Button();
            this.btnQuestionG = new System.Windows.Forms.Button();
            this.btnSqlServer2022 = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = StyleConfig.PrimaryBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 80);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = StyleConfig.TitleFont;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 80);
            this.lblTitle.Text = "Visual Programming Assignment 2";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlButtons
            this.pnlButtons.AutoScroll = true;
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 80);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.pnlButtons.Size = new System.Drawing.Size(600, 320);

            // Buttons
            System.Windows.Forms.Button[] buttons = {
                btnQuestionA, btnQuestionB, btnQuestionC,
                btnQuestionD, btnQuestionE, btnQuestionF,
                btnQuestionG, btnSqlServer2022
            };
            string[] texts = {
                "A) Arrays & Files", "B) Loops Test", "C) SQL & LINQ",
                "D) Student Scores", "E) Bank Account", "F) Power & Ref",
                "G) UI Controls", "SQL Server 2022 demo"
            };
            System.EventHandler[] handlers = {
                btnQuestionA_Click, btnQuestionB_Click, btnQuestionC_Click,
                btnQuestionD_Click, btnQuestionE_Click, btnQuestionF_Click,
                btnQuestionG_Click, btnSqlServer2022_Click
            };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new System.Windows.Forms.Button();
                buttons[i].Size = new System.Drawing.Size(240, 50);
                buttons[i].Margin = new System.Windows.Forms.Padding(10);
                buttons[i].Text = texts[i];
                StyleConfig.ApplyButtonStyle(buttons[i]);
                buttons[i].Click += handlers[i];
                this.pnlButtons.Controls.Add(buttons[i]);
            }

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment Dashboard";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnQuestionA;
        private System.Windows.Forms.Button btnQuestionB;
        private System.Windows.Forms.Button btnQuestionC;
        private System.Windows.Forms.Button btnQuestionD;
        private System.Windows.Forms.Button btnQuestionE;
        private System.Windows.Forms.Button btnQuestionF;
        private System.Windows.Forms.Button btnQuestionG;
        private System.Windows.Forms.Button btnSqlServer2022;
    }
}
