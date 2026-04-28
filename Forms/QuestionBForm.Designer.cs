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
            this.SuspendLayout();

            // btnRun
            this.btnRun.Location = new System.Drawing.Point(20, 20);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(150, 30);
            this.btnRun.Text = "Run While Loop Test";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);

            // txtOutput
            this.txtOutput.Location = new System.Drawing.Point(20, 60);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(400, 200);

            // QuestionBForm
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtOutput);
            this.Name = "QuestionBForm";
            this.Text = "Question B - While, Break & Continue";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtOutput;
    }
}
