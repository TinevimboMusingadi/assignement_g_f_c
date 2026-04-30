using System;
using System.Windows.Forms;
using Assignment.Models;
using Assignment.Exceptions;

namespace Assignment.Forms
{
    public partial class QuestionDForm : Form
    {
        public QuestionDForm()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse inputs
                string name = txtStudentName.Text.Trim();
                int test1 = int.Parse(txtTest1.Text);
                int test2 = int.Parse(txtTest2.Text);

                // Instantiate Student (may throw NegativeMarkException or ArgumentException)
                Student s = new Student(name, test1, test2);

                // Display average
                double avg = s.CalculateAverage();
                lblAverage.Text = $"Average: {avg:F1}";

                // Update ListBox if passed
                if (s.HasPassed())
                {
                    if (!lstPassedStudents.Items.Contains(s.Name))
                        lstPassedStudents.Items.Add(s.Name);
                    
                    MessageBox.Show($"{s.Name} passed with average {avg:F1}!", "Success");
                }
                else
                {
                    MessageBox.Show($"{s.Name} did not pass (Average: {avg:F1})", "Result");
                }
            }
            catch (NegativeMarkException ex)
            {
                MessageBox.Show("❌ Custom Exception: " + ex.Message, "Negative Mark Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid integer values for test scores.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }

        private void btnWhyException_Click(object sender, EventArgs e)
        {
            string explanation = "Why Exception Handling Matters in Event-Driven Apps:\n\n" +
                                 "1. Prevents Crashes: A single invalid input won't crash the whole app.\n" +
                                 "2. User Experience: Provides clear, friendly messages instead of cryptic system errors.\n" +
                                 "3. UI Stability: Keeps the interface responsive and prevents freezes.\n" +
                                 "4. Graceful Recovery: Allows the user to fix the error and continue working.";
            MessageBox.Show(explanation, "Exception Handling Importance");
        }
    }
}
