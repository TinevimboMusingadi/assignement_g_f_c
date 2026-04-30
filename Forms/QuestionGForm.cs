using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Assignment.Forms
{
    public partial class QuestionGForm : Form
    {
        public QuestionGForm()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);
            PopulateCheckedListBox();
            SetupTreeView();
        }

        private void PopulateCheckedListBox()
        {
            checkedListBox1.Items.Add("Mathematics");
            checkedListBox1.Items.Add("Science");
            checkedListBox1.Items.Add("English");
            checkedListBox1.Items.Add("History");
            checkedListBox1.Items.Add("Computer Science");
        }

        private void SetupTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("root", "📅 Scheduled Subjects");
        }

        // ---- Button: Add selected subjects under selected date ----
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("dd MMM yyyy");

            // Find or create a date node
            TreeNode dateNode = null;
            foreach (TreeNode node in treeView1.Nodes[0].Nodes)
            {
                if (node.Text == selectedDate)
                {
                    dateNode = node;
                    break;
                }
            }

            if (dateNode == null)
            {
                dateNode = new TreeNode(selectedDate);
                treeView1.Nodes[0].Nodes.Add(dateNode);
            }

            // Add checked subjects under the date node
            int added = 0;
            foreach (object item in checkedListBox1.CheckedItems)
            {
                string subject = item.ToString();
                bool exists = false;
                foreach (TreeNode child in dateNode.Nodes)
                {
                    if (child.Text == subject)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    dateNode.Nodes.Add(subject);
                    added++;
                }
            }

            treeView1.ExpandAll();

            if (added == 0)
                MessageBox.Show("No new subjects added. Either none checked or already added for this date.");
            else
                MessageBox.Show($"{added} subject(s) added for {selectedDate}.");
        }

        // ---- CheckedListBox: Show selection summary ----
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Count will include pending change
            int count = checkedListBox1.CheckedItems.Count +
                        (e.NewValue == CheckState.Checked ? 1 : -1);
            lblStatus.Text = $"{count} subject(s) selected";
        }

        // ---- LinkLabel: Open URL ----
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            try
            {
                Process.Start(new ProcessStartInfo("https://learn.microsoft.com/en-us/dotnet/")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open link: " + ex.Message);
            }
        }

        // ---- TreeView: Show selected node info ----
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblStatus.Text = $"Selected: {e.Node.Text}";
        }
    }
}
