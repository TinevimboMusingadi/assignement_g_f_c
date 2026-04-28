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
            this.SuspendLayout();

            // TextBoxes (Simplified positioning for brevity)
            int startY = 20;
            System.Windows.Forms.TextBox[] boxes = { txtNum1, txtNum2, txtNum3, txtNum4, txtNum5, txtNum6, txtNum7, txtNum8 };
            for (int i = 0; i < 8; i++)
            {
                boxes[i].Location = new System.Drawing.Point(20, startY + (i * 30));
                boxes[i].Size = new System.Drawing.Size(100, 23);
                this.Controls.Add(boxes[i]);
            }

            // btnProcess
            this.btnProcess.Location = new System.Drawing.Point(140, 20);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(100, 30);
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);

            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(140, 70);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(38, 15);
            this.lblResult.Text = "Results will appear here";

            // lvResults
            this.lvResults.Location = new System.Drawing.Point(140, 100);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(300, 150);

            // QuestionAForm
            this.ClientSize = new System.Drawing.Size(480, 300);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lvResults);
            this.Name = "QuestionAForm";
            this.Text = "Question A - Arrays & File I/O";
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
    }
}
