namespace Assignment.Forms
{
    public partial class QuestionBForm : Form
    {
        public QuestionBForm()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int[] testArray = { 9, -3, 6, 0, 15, 7, -1, 12 };
            txtOutput.Clear();
            ProcessArray(testArray);
        }

        public void ProcessArray(int[] numbers)
        {
            int index = 0;
            txtOutput.AppendText("Starting processing...\r\n");

            while (index < numbers.Length)
            {
                int current = numbers[index];

                // Skip negative numbers using continue
                if (current < 0)
                {
                    txtOutput.AppendText($"Skipping negative number: {current}\r\n");
                    index++;
                    continue;
                }

                // Stop processing if we encounter 0 (sentinel value)
                if (current == 0)
                {
                    txtOutput.AppendText("Zero encountered. Stopping processing.\r\n");
                    break;
                }

                // Process valid positive numbers
                txtOutput.AppendText($"Processing: {current}\r\n");

                if (current % 3 == 0)
                    txtOutput.AppendText($"  --> {current} is divisible by 3\r\n");

                index++;
            }

            txtOutput.AppendText("Processing complete.\r\n");
        }
    }
}
