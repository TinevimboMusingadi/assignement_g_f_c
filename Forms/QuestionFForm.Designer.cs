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
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Power Calculation & Ref Parameters";
            StyleConfig.ApplyLabelStyle(this.lblTitle, true);

            // lblBase, txtBase
            this.lblBase.Location = new System.Drawing.Point(20, 50);
            this.lblBase.Text = "Base (x):";
            StyleConfig.ApplyLabelStyle(this.lblBase);
            this.txtBase.Location = new System.Drawing.Point(140, 50);
            this.txtBase.Size = new System.Drawing.Size(100, 23);

            // lblExponent, txtExponent
            this.lblExponent.Location = new System.Drawing.Point(20, 85);
            this.lblExponent.Text = "Exponent (y):";
            StyleConfig.ApplyLabelStyle(this.lblExponent);
            this.txtExponent.Location = new System.Drawing.Point(140, 85);
            this.txtExponent.Size = new System.Drawing.Size(100, 23);

            // btnCalculate
            this.btnCalculate.Location = new System.Drawing.Point(20, 125);
            this.btnCalculate.Size = new System.Drawing.Size(120, 40);
            this.btnCalculate.Text = "Calculate";
            StyleConfig.ApplyButtonStyle(this.btnCalculate);
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // lblResult
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = StyleConfig.PrimaryBlue;
            this.lblResult.Location = new System.Drawing.Point(150, 125);
            this.lblResult.Size = new System.Drawing.Size(180, 40);
            this.lblResult.Text = "Result: -";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblRefDemo
            this.lblRefDemo.BackColor = System.Drawing.Color.LightYellow;
            this.lblRefDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRefDemo.Location = new System.Drawing.Point(20, 180);
            this.lblRefDemo.Size = new System.Drawing.Size(310, 30);
            this.lblRefDemo.Text = "ref demo status: Waiting...";
            this.lblRefDemo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnRefExplanation
            this.btnRefExplanation.Location = new System.Drawing.Point(20, 220);
            this.btnRefExplanation.Size = new System.Drawing.Size(180, 35);
            this.btnRefExplanation.Text = "Ref vs Value Explained";
            StyleConfig.ApplyButtonStyle(this.btnRefExplanation, false);
            this.btnRefExplanation.Click += new System.EventHandler(this.btnRefExplanation_Click);

            // QuestionFForm
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.lblExponent);
            this.Controls.Add(this.txtExponent);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblRefDemo);
            this.Controls.Add(this.btnRefExplanation);
            this.Name = "QuestionFForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label lblTitle;
    }
}
