namespace Assignment.Forms
{
    public partial class QuestionAForm : Form
    {
        public QuestionAForm()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);

            // Setup ListView columns
            lvResults.View = View.Details;
            lvResults.Columns.Add("Index", 80);
            lvResults.Columns.Add("Value", 120);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int[] numbers = new int[8];
            TextBox[] boxes = { txtNum1, txtNum2, txtNum3, txtNum4,
                                txtNum5, txtNum6, txtNum7, txtNum8 };

            // Accept 8 integers
            for (int i = 0; i < 8; i++)
            {
                if (!int.TryParse(boxes[i].Text, out numbers[i]))
                {
                    MessageBox.Show($"Invalid input at box {i + 1}. Enter integers only.");
                    return;
                }
            }

            // Compute maximum value
            int max = numbers[0];
            int divisibleBy3Count = 0;

            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] > max) max = numbers[i];

            // Count divisible by 3
            foreach (int n in numbers)
                if (n % 3 == 0) divisibleBy3Count++;

            lblResult.Text = $"Max: {max} | Divisible by 3: {divisibleBy3Count}";

            // Write to text file
            string filePath = "numbers.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (int n in numbers)
                        sw.WriteLine(n);
                }

                // Read file and display in ListView
                lvResults.Items.Clear();
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(lines[i]);
                    lvResults.Items.Add(item);
                }

                MessageBox.Show("Done! File written and ListView updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
