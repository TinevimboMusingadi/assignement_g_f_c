namespace Assignment.Forms
{
    partial class QuestionFForm
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
            this.txtBase = new System.Windows.Forms.TextBox();
            this.txtExponent = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.lblExponent = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRefDemo = new System.Windows.Forms.Label();
            this.btnRefExplanation = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblBase, txtBase
            this.lblBase.Location = new System.Drawing.Point(20, 20);
            this.lblBase.Text = "Base (x):";
            this.txtBase.Location = new System.Drawing.Point(130, 20);
            this.txtBase.Size = new System.Drawing.Size(100, 23);

            // lblExponent, txtExponent
            this.lblExponent.Location = new System.Drawing.Point(20, 50);
            this.lblExponent.Text = "Exponent (y):";
            this.txtExponent.Location = new System.Drawing.Point(130, 50);
            this.txtExponent.Size = new System.Drawing.Size(100, 23);

            // btnCalculate
            this.btnCalculate.Location = new System.Drawing.Point(20, 90);
            this.btnCalculate.Size = new System.Drawing.Size(100, 30);
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // lblResult
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(130, 90);
            this.lblResult.Size = new System.Drawing.Size(150, 30);
            this.lblResult.Text = "Result: -";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblRefDemo
            this.lblRefDemo.Location = new System.Drawing.Point(20, 140);
            this.lblRefDemo.Size = new System.Drawing.Size(260, 20);
            this.lblRefDemo.Text = "ref demo: -";

            // btnRefExplanation
            this.btnRefExplanation.Location = new System.Drawing.Point(20, 170);
            this.btnRefExplanation.Size = new System.Drawing.Size(150, 30);
            this.btnRefExplanation.Text = "What are Ref Params?";
            this.btnRefExplanation.Click += new System.EventHandler(this.btnRefExplanation_Click);

            // QuestionFForm
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.lblExponent);
            this.Controls.Add(this.txtExponent);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblRefDemo);
            this.Controls.Add(this.btnRefExplanation);
            this.Name = "QuestionFForm";
            this.Text = "Question F - Power & Ref";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.TextBox txtExponent;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Label lblExponent;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblRefDemo;
        private System.Windows.Forms.Button btnRefExplanation;
    }
}
