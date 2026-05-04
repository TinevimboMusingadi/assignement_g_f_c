using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;

namespace Assignment.Forms
{
    public partial class QuestionCForm : Form
    {
        // Match MySQL Workbench: localhost, port 3306, user root. Set Password if yours is non-empty.
        private const string MySqlHost = "127.0.0.1";
        private const uint MySqlPort = 3306;
        private const string MySqlUser = "root";
        private const string MySqlPassword = "Topikaa51!";
        private const string MySqlDatabase = "assignmentdb";
        // Unknown database — first run has no schema until Setup DB or EnsureMySqlSchemaAndSeed runs.
        private const int MySqlErBadDbError = 1049;

        public QuestionCForm()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);
            Load += QuestionCForm_Load;
        }

        private void QuestionCForm_Load(object? sender, EventArgs e)
        {
            LoadProducts();
        }

        private static string ConnectionString(bool includeDatabase)
        {
            var b = new MySqlConnectionStringBuilder
            {
                Server = MySqlHost,
                Port = MySqlPort,
                UserID = MySqlUser,
                Password = MySqlPassword,
            };
            if (includeDatabase)
                b.Database = MySqlDatabase;
            return b.ConnectionString;
        }

        private static string ConnectionDiagnosticSuffix()
        {
            return "\n\nActive connection (password hidden):\n" +
                   $"Server={MySqlHost};Port={MySqlPort};User ID={MySqlUser};Database={MySqlDatabase};";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            LoadProducts(autoCreateMissingDatabase: true);
        }

        private void LoadProducts(bool autoCreateMissingDatabase)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString(true)))
                {
                    using (var adapter = new MySqlDataAdapter("SELECT * FROM Products", conn))
                    {
                        var ds = new DataSet();
                        adapter.Fill(ds, "Products");
                        dataGridView1.DataSource = ds.Tables["Products"];
                    }
                }
            }
            catch (MySqlException ex) when (autoCreateMissingDatabase && ex.Number == MySqlErBadDbError)
            {
                try
                {
                    EnsureMySqlSchemaAndSeed(notifyUserOnSuccess: false);
                    LoadProducts(autoCreateMissingDatabase: false);
                }
                catch (MySqlException ex2)
                {
                    MessageBox.Show(
                        "Could not create or open database '" + MySqlDatabase + "': " + ex2.Message
                        + "\n\nClick Setup DB after fixing permissions, or run Scripts\\SetupAssignmentDB_MySQL.sql in Workbench."
                        + ConnectionDiagnosticSuffix(),
                        "Database error");
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Setup / load failed: " + ex2.Message + ConnectionDiagnosticSuffix(), "Database error");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error loading: " + ex.Message +
                    "\n\nEnsure MySQL is running, database '" + MySqlDatabase + "' exists, and table 'Products' exists " +
                    "(click Setup DB, or run Scripts\\SetupAssignmentDB_MySQL.sql in Workbench)." +
                    ConnectionDiagnosticSuffix(),
                    "Database error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message + ConnectionDiagnosticSuffix(), "Database error");
            }
        }

        // Creates assignmentdb when missing, Products table if needed, inserts seed rows when empty.
        private void EnsureMySqlSchemaAndSeed(bool notifyUserOnSuccess)
        {
            using (var conn = new MySqlConnection(ConnectionString(false)))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                           "CREATE DATABASE IF NOT EXISTS `" + MySqlDatabase + "`;",
                           conn))
                    cmd.ExecuteNonQuery();
            }

            using (var conn = new MySqlConnection(ConnectionString(true)))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(@"
CREATE TABLE IF NOT EXISTS Products (
    ProductID INT NOT NULL AUTO_INCREMENT,
    ProductName VARCHAR(100) NULL,
    Price DECIMAL(10, 2) NULL,
    Stock INT NULL,
    PRIMARY KEY (ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;",
                        conn))
                    cmd.ExecuteNonQuery();

                long count;
                using (var cnt = new MySqlCommand("SELECT COUNT(*) FROM Products", conn))
                    count = (long)cnt.ExecuteScalar()!;

                if (count == 0)
                {
                    const string insertSql =
                        @"INSERT INTO Products (ProductName, Price, Stock) VALUES (@n0,@p0,@s0),(@n1,@p1,@s1),(@n2,@p2,@s2),(@n3,@p3,@s3)";
                    using (var ins = new MySqlCommand(insertSql, conn))
                    {
                        ins.Parameters.AddWithValue("@n0", "Laptop");
                        ins.Parameters.AddWithValue("@p0", 999.99m);
                        ins.Parameters.AddWithValue("@s0", 15);
                        ins.Parameters.AddWithValue("@n1", "Mouse");
                        ins.Parameters.AddWithValue("@p1", 25m);
                        ins.Parameters.AddWithValue("@s1", 100);
                        ins.Parameters.AddWithValue("@n2", "Monitor");
                        ins.Parameters.AddWithValue("@p2", 350m);
                        ins.Parameters.AddWithValue("@s2", 30);
                        ins.Parameters.AddWithValue("@n3", "Keyboard");
                        ins.Parameters.AddWithValue("@p3", 75m);
                        ins.Parameters.AddWithValue("@s3", 60);
                        ins.ExecuteNonQuery();
                    }
                }
            }

            if (notifyUserOnSuccess)
            {
                MessageBox.Show(
                    "MySQL database setup finished. Connection: "
                    + $"{MySqlHost}:{MySqlPort}, database `{MySqlDatabase}`. Refresh Data to reload the grid.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString(true)))
                {
                    conn.Open();
                    const string query = "INSERT INTO Products (ProductName, Price, Stock) VALUES (@Name, @Price, @Stock)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Product inserted successfully!");
                    LoadProducts();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Ensure Price is a number and Stock is an integer.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message + ConnectionDiagnosticSuffix());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString(true)))
                {
                    conn.Open();
                    const string query =
                        "UPDATE Products SET Price = @Price, Stock = @Stock WHERE ProductName = @Name";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Updated!" : "Product not found.");
                    }

                    LoadProducts();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message + ConnectionDiagnosticSuffix());
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid price or stock format.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ConnectionDiagnosticSuffix());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString(true)))
                {
                    conn.Open();
                    const string query = "DELETE FROM Products WHERE ProductName = @Name";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Deleted!" : "Product not found.");
                    }

                    LoadProducts();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message + ConnectionDiagnosticSuffix());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ConnectionDiagnosticSuffix());
            }
        }

        private void btnLinq_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString(true)))
                {
                    using (var adapter = new MySqlDataAdapter("SELECT * FROM Products", conn))
                    {
                        var ds = new DataSet();
                        adapter.Fill(ds, "Products");
                        DataTable? table = ds.Tables["Products"];
                        if (table == null || table.Rows.Count == 0)
                        {
                            MessageBox.Show("No product rows loaded. Run Setup DB or Refresh Data first.");
                            return;
                        }

                        var expensiveProducts = table.AsEnumerable()
                            .Where(row => row.Field<decimal>("Price") > 100)
                            .Select(row => new {
                                Name = row.Field<string>("ProductName"),
                                Price = row.Field<decimal>("Price"),
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
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "LINQ / database error: " + ex.Message + ConnectionDiagnosticSuffix(),
                    "Database error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("LINQ error: " + ex.Message);
            }
        }

        private void btnLinqAdvantages_Click(object sender, EventArgs e)
        {
            const string advantages = "Advantages of LINQ:\n" +
                                      "- Type-safe: Errors caught at compile time.\n" +
                                      "- Readable: SQL-like syntax directly in C#.\n" +
                                      "- Versatile: Works on arrays, lists, SQL, XML.\n" +
                                      "- IntelliSense: Full IDE support.\n" +
                                      "- Less Boilerplate: Replaces complex loops with one-liners.";
            MessageBox.Show(advantages, "LINQ Advantages");
        }

        private void btnSetupDb_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureMySqlSchemaAndSeed(notifyUserOnSuccess: true);
                LoadProducts(autoCreateMissingDatabase: false);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Setup failed (MySQL): " + ex.Message
                    + "\n\nEnsure MySQL 8.x is running and user '" + MySqlUser + "' can create databases."
                    + ConnectionDiagnosticSuffix(),
                    "Setup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Setup failed: " + ex.Message + ConnectionDiagnosticSuffix(),
                    "Setup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
