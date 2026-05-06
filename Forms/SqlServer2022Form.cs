using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Assignment.Forms
{
    public partial class SqlServer2022Form : Form
    {
        private const string SqlDatabaseName = "AssignmentDB";

        private static readonly bool UseSqlLoginAuth =
            string.Equals(Environment.GetEnvironmentVariable("MSSQL_USE_SQL_AUTH"), "1", StringComparison.OrdinalIgnoreCase);
        private const string SqlUser = "sa";
        private const string SqlPassword = "ChangeMe!";

        public SqlServer2022Form()
        {
            InitializeComponent();
            StyleConfig.ApplyFormStyle(this);

            cmbServer.BeginUpdate();
            cmbServer.Items.AddRange(new object[]
            {
                ".",
                @".\SQLEXPRESS",
                "(local)",
                @"(local)\SQLEXPRESS",
                @"localhost",
                @"localhost\SQLEXPRESS",
                @"(localdb)\MSSQLLocalDB",
            });
            cmbServer.EndUpdate();

            string? env = Environment.GetEnvironmentVariable("MSSQL_SERVER");
            string initial = string.IsNullOrWhiteSpace(env) ? "." : env.Trim();
            bool envMatchesItem = false;
            for (int i = 0; i < cmbServer.Items.Count; i++)
            {
                if (string.Equals(cmbServer.Items[i]?.ToString(), initial, StringComparison.OrdinalIgnoreCase))
                {
                    cmbServer.SelectedIndex = i;
                    envMatchesItem = true;
                    break;
                }
            }

            if (!envMatchesItem)
            {
                cmbServer.Text = initial;
            }

            Load += SqlServer2022Form_Load;
        }

        private void SqlServer2022Form_Load(object? sender, EventArgs e) => TryLoadGrid();

        private string CurrentDataSource => cmbServer.Text.Trim();

        private string ConnectionString(string database)
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = CurrentDataSource,
                InitialCatalog = database,
                TrustServerCertificate = true,
                Encrypt = true,
            };
            if (!UseSqlLoginAuth)
            {
                b.IntegratedSecurity = true;
            }
            else
            {
                b.UserID = SqlUser;
                b.Password = SqlPassword;
            }

            return b.ConnectionString;
        }

        private string DiagnosticConnectionText()
        {
            return "\n\nActive connection (password hidden):\n"
                   + $"Server={CurrentDataSource}; Database={SqlDatabaseName}; "
                   + (!UseSqlLoginAuth ? "Integrated Security=True" : $"User ID={SqlUser}") + ";";
        }

        private static bool LooksLikeError26(SqlException ex)
        {
            string m = ex.Message;
            return m.IndexOf("error: 26", StringComparison.OrdinalIgnoreCase) >= 0
                   || m.IndexOf("SQL Network Interfaces", StringComparison.OrdinalIgnoreCase) >= 0
                   || m.IndexOf("Error Locating Server/Instance", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool LooksLikeOtherConnectivity(SqlException ex)
        {
            string m = ex.Message;
            return m.IndexOf("40 - Could not open a connection", StringComparison.OrdinalIgnoreCase) >= 0
                   || m.IndexOf("could not open a connection", StringComparison.OrdinalIgnoreCase) >= 0
                   || m.IndexOf("Named Pipes Provider", StringComparison.OrdinalIgnoreCase) >= 0
                   || ex.Number == -2;
        }

        private static string TroubleshootingGeneral()
        {
            return "\n\nGeneral fixes:\n"
                   + "- In SSMS, use Browse for Servers → Database Engine → copy your exact instance name.\n"
                   + "- Run services.msc: start SQL Server (MSSQLSERVER) OR SQL Server (SQLEXPRESS).\n";
        }

        private static string TroubleshootingError26()
        {
            return "\n\nError 26 — instance name not found:\n"
                   + "- Open \"SQL Server 2022 Configuration Manager\" → SQL Server Services.\n"
                   + "  If you only see \"SQL Server (MSSQLSERVER)\", choose \".\" here (not SQLEXPRESS).\n"
                   + "  If you see NO SQL rows, SQL Server isn't installed.\n"
                   + "- SQLEXPRESS only exists after installing \"Express\" edition with that named instance.\n"
                   + "- Start \"SQL Server Browser\" if browsing server lists (helps some setups).\n"
                   + "- For Visual Studio LocalDB try: (localdb)\\MSSQLLocalDB (with LocalDB installed).\n";
        }

        private string ExtraHelp(SqlException ex)
        {
            if (LooksLikeError26(ex))
            {
                return TroubleshootingError26() + TroubleshootingGeneral();
            }

            if (LooksLikeOtherConnectivity(ex))
            {
                return TroubleshootingGeneral()
                       + "- Remote: firewall + TCP/IP enabled in Configuration Manager.";
            }

            return "";
        }

        private void TryLoadGrid()
        {
            if (string.IsNullOrEmpty(CurrentDataSource))
            {
                MessageBox.Show("Choose or type a Server instance.", "SQL Server");
                return;
            }

            try
            {
                using var conn = new SqlConnection(ConnectionString(SqlDatabaseName));
                using var adapter = new SqlDataAdapter(
                    "SELECT ProductID, ProductName, Price, Stock FROM dbo.Products", conn);
                var ds = new DataSet();
                adapter.Fill(ds, "Products");
                dataGridView1.DataSource = ds.Tables["Products"];
            }
            catch (SqlException ex) when (ex.Number == 4060)
            {
                MessageBox.Show(
                    "Cannot open database. Click \"Setup SQL DB\" or run Scripts\\SetupAssignmentDB.sql in SSMS."
                    + DiagnosticConnectionText(),
                    "SQL Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "SQL error: " + ex.Message + DiagnosticConnectionText() + ExtraHelp(ex),
                    "SQL Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => TryLoadGrid();

        private void btnSetup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentDataSource))
            {
                MessageBox.Show("Choose or type a Server instance first.", "SQL Server");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(ConnectionString("master")))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                               $@"IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'{SqlDatabaseName}')
BEGIN
    CREATE DATABASE [{SqlDatabaseName}];
END",
                               conn))
                        cmd.ExecuteNonQuery();
                }

                using (var conn = new SqlConnection(ConnectionString(SqlDatabaseName)))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(
                               @"
IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products (
        ProductID   INT IDENTITY PRIMARY KEY,
        ProductName NVARCHAR(100) NULL,
        Price       DECIMAL(10, 2) NULL,
        Stock       INT NULL
    );
END",
                               conn))
                        cmd.ExecuteNonQuery();

                    long count;
                    using (var cnt = new SqlCommand("SELECT COUNT(*) FROM dbo.Products", conn))
                        count = (long)cnt.ExecuteScalar()!;

                    if (count == 0)
                    {
                        const string insert = @"
INSERT INTO dbo.Products (ProductName, Price, Stock)
VALUES (N'Laptop', 999.99, 15),
       (N'Mouse', 25.00, 100),
       (N'Monitor', 350.00, 30),
       (N'Keyboard', 75.00, 60);";
                        using var ins = new SqlCommand(insert, conn);
                        ins.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"SQL Server database [{SqlDatabaseName}] is ready on [{CurrentDataSource}].",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                TryLoadGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Setup failed: " + ex.Message
                    + "\n\nEnsure the instance exists, SQL Server service is running, and your login can create databases."
                    + DiagnosticConnectionText()
                    + ExtraHelp(ex),
                    "SQL Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
