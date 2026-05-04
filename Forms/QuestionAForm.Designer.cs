using System.Drawing;
using System.Windows.Forms;

namespace Assignment.Forms
{
    partial class QuestionAForm
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
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.txtNum2 = new System.Windows.Forms.TextBox();
            this.txtNum3 = new System.Windows.Forms.TextBox();
            this.txtNum4 = new System.Windows.Forms.TextBox();
            this.txtNum5 = new System.Windows.Forms.TextBox();
            this.txtNum6 = new System.Windows.Forms.TextBox();
            this.txtNum7 = new System.Windows.Forms.TextBox();
            this.txtNum8 = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lvResults = new System.Windows.Forms.ListView();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblInstructions
            this.lblInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(20, 15);
            this.lblInstructions.Text = "Enter 8 integers below:";
            StyleConfig.ApplyLabelStyle(this.lblInstructions, true);

            // TextBoxes in a loop
            System.Windows.Forms.TextBox[] boxes = { txtNum1, txtNum2, txtNum3, txtNum4, txtNum5, txtNum6, txtNum7, txtNum8 };
            for (int i = 0; i < 8; i++)
            {
                boxes[i].Anchor = AnchorStyles.Top | AnchorStyles.Left;
                boxes[i].Location = new System.Drawing.Point(20, 50 + (i * 35));
                boxes[i].Size = new System.Drawing.Size(120, 23);
                this.Controls.Add(boxes[i]);
            }

            // btnProcess
            this.btnProcess.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnProcess.Location = new System.Drawing.Point(165, 50);
            this.btnProcess.Size = new System.Drawing.Size(140, 40);
            this.btnProcess.Text = "Process Data";
            StyleConfig.ApplyButtonStyle(this.btnProcess);
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);

            // lblResult
            this.lblResult.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(165, 100);
            this.lblResult.Text = "Results: Pending input...";
            StyleConfig.ApplyLabelStyle(this.lblResult);

            // lvResults
            this.lvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.Location = new System.Drawing.Point(165, 128);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(315, 212);

            // QuestionAForm
            this.ClientSize = new System.Drawing.Size(504, 360);
            this.MinimumSize = new System.Drawing.Size(420, 300);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lvResults);
            this.Name = "QuestionAForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question A - Arrays & Files";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.TextBox txtNum2;
        private System.Windows.Forms.TextBox txtNum3;
        private System.Windows.Forms.TextBox txtNum4;
        private System.Windows.Forms.TextBox txtNum5;
        private System.Windows.Forms.TextBox txtNum6;
        private System.Windows.Forms.TextBox txtNum7;
        private System.Windows.Forms.TextBox txtNum8;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.Label lblInstructions;
    }
}
