using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Assignment.Forms
{
    public partial class QuestionCForm : Form
    {
        // Update this connection string to match your SQL Server
        private string connStr = @"Server=.\SQLEXPRESS;Database=AssignmentDB;Integrated Security=True;";

        public QuestionCForm()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Products");
                    dataGridView1.DataSource = ds.Tables["Products"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message + "\n\nMake sure SQL Server is running and the database 'AssignmentDB' exists with a 'Products' table.");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO Products (ProductName, Price, Stock) VALUES (@Name, @Price, @Stock)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product inserted successfully!");
                    LoadProducts();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Ensure Price is a number and Stock is an integer.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE Products SET Price = @Price, Stock = @Stock WHERE ProductName = @Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Updated!" : "Product not found.");
                    LoadProducts();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Products WHERE ProductName = @Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Deleted!" : "Product not found.");
                    LoadProducts();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLinq_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource == null)
                {
                    MessageBox.Show("Load products first.");
                    return;
                }

                DataTable dt = (DataTable)dataGridView1.DataSource;

                // LINQ query on DataTable
                var expensiveProducts = dt.AsEnumerable()
                    .Where(row => row.Field<decimal>("Price") > 100)
                    .Select(row => new {
                        Name = row.Field<string>("ProductName"),
                        Price = row.Field<decimal>("Price")
                    });

                int count = expensiveProducts.Count();
                if (count == 0)
                {
                    MessageBox.Show("No products found with price > 100.");
                    return;
                }

                double avg = expensiveProducts.Average(p => (double)p.Price);

                MessageBox.Show($"Products > $100:\nCount: {count}\nAverage Price: ${avg:F2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("LINQ error: " + ex.Message);
            }
        }

        private void btnLinqAdvantages_Click(object sender, EventArgs e)
        {
            string advantages = "Advantages of LINQ:\n" +
                                "- Type-safe: Errors caught at compile time.\n" +
                                "- Readable: SQL-like syntax directly in C#.\n" +
                                "- Versatile: Works on arrays, lists, SQL, XML.\n" +
                                "- IntelliSense: Full IDE support.\n" +
                                "- Less Boilerplate: Replaces complex loops with one-liners.";
            MessageBox.Show(advantages, "LINQ Advantages");
        }
    }
}
