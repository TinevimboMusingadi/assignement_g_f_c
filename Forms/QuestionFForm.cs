using System;
using System.Windows.Forms;

namespace Assignment.Forms
{
    public partial class QuestionFForm : Form
    {
        public QuestionFForm()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);
        }

        // ---- Power method using iterative multiplication ----
        public static int Power(int x, int y)
        {
            if (y < 0)
                throw new ArgumentException($"Exponent must be >= 0. Got: {y}");

            int result = 1;
            for (int i = 0; i < y; i++)
                result *= x;

            return result;
        }

        // ---- Ref parameter demonstration ----
        // ref allows the method to modify the caller's variable directly
        public static void DoubleIt(ref int value)
        {
            value *= 2;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtBase.Text);
                int y = int.Parse(txtExponent.Text);

                int result = Power(x, y);
                lblResult.Text = $"{x}^{y} = {result}";

                // Ref example
                int sample = 5;
                int original = sample;
                DoubleIt(ref sample);
                lblRefDemo.Text = $"ref demo (DoubleIt): {original} → {sample}"; // shows 10
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Power error: " + ex.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter valid integer values.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefExplanation_Click(object sender, EventArgs e)
        {
            string explanation = "Ref Parameters - Quick Explanation:\n\n" +
                                 "- Pass by Reference: Passes the variable itself, not a copy.\n" +
                                 "- Persistence: Changes made inside the method affect the original variable.\n" +
                                 "- Requirement: The variable must be initialized before being passed as 'ref'.";
            MessageBox.Show(explanation, "Ref Parameters Info");
        }
    }
}
