using System.Drawing;
using System.Windows.Forms;

namespace Assignment.Forms
{
    partial class QuestionBForm
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
            this.btnRun = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "While Loop, Break & Continue Demo";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            // btnRun
            this.btnRun.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnRun.Location = new System.Drawing.Point(20, 60);
            this.btnRun.Size = new System.Drawing.Size(200, 40);
            this.btnRun.Text = "Run Sequence Test";
            StyleConfig.ApplyButtonStyle(this.btnRun);
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);

            // txtOutput
            this.txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(16, 24, 48);
            this.txtOutput.ForeColor = System.Drawing.Color.FromArgb(0, 255, 128); // Matrix green for output
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtOutput.Location = new System.Drawing.Point(20, 115);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(460, 225);

            // QuestionBForm
            this.MinimumSize = new System.Drawing.Size(400, 280);
            this.ClientSize = new System.Drawing.Size(500, 360);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtOutput);
            this.Name = "QuestionBForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question B - Loops";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblTitle;
    }
}
