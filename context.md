# 🖥️ Visual Programming Assignment 2 — Complete Guide
> **Total: 100 Marks | Platform: Windows Forms (C# / .NET) | IDE: Visual Studio**

---

## 📋 Table of Contents
- [How to Set Up Visual Studio](#-how-to-set-up-visual-studio)
- [Question A — Arrays, File I/O & ListView](#a-windows-forms-array--file-io--listview)
- [Question B — While Loop, Break & Continue](#b-while-loop-break-and-continue)
- [Question C — SQL Server, DataGridView & LINQ](#c-sql-server-datagridview--linq)
- [Question D — Student Scores & Custom Exception](#d-student-scores--custom-exception)
- [Question E — BankAccount Class](#e-bankaccount-class)
- [Question F — Power Method with Ref Parameters](#f-power-method-with-ref-parameters)
- [Question G — Event-Driven UI Controls](#g-event-driven-ui-controls)

---

## 🛠️ How to Set Up Visual Studio

1. Download **Visual Studio Community** (free): https://visualstudio.microsoft.com/
2. During install, select workload: **".NET Desktop Development"**
3. For each question below, create a new project:
   - `File` → `New` → `Project`
   - Choose **"Windows Forms App (.NET Framework)"** or **"Windows Forms App (.NET 6/8)"**
   - Name the project (e.g., `QuestionA`)
4. Open `Form1.cs` (or `Form1.Designer.cs`) to add controls and code

---

## A) Windows Forms: Array, File I/O & ListView

### 📌 What It Does
- Accepts 8 integers into an array
- Finds the maximum value
- Counts numbers divisible by 3
- Writes array values to a text file
- Reads the file and displays contents in a `ListView`

### 🪟 Form Design (Designer)
Add to `Form1.Designer.cs` or drag-drop in Designer:
- 8x `TextBox` (name them `txtNum1` through `txtNum8`)
- 1x `Button` → `btnProcess`, Text = "Process"
- 1x `Label` → `lblResult`
- 1x `ListView` → `lvResults`

### 💻 Code — `Form1.cs`

```csharp
using System;
using System.IO;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Setup ListView columns
        lvResults.View = View.Details;
        lvResults.Columns.Add("Index", 80);
        lvResults.Columns.Add("Value", 80);
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
}
```

### ▶️ How to Run
1. Create new **Windows Forms App** project named `QuestionA`
2. Open `Form1.cs` in design view and add 8 TextBoxes, 1 Button, 1 Label, 1 ListView
3. Name controls as described above
4. Paste the code into `Form1.cs`
5. Press **F5** to run
6. Enter 8 numbers, click **Process**
7. Check output in the ListView and `numbers.txt` in the project's `bin/Debug` folder

---

## B) While Loop, Break and Continue

### 📌 What It Does
Processes an integer array using a `while` loop with `break` and `continue`.

### 💻 Code — Method Only (add inside `Form1.cs`)

```csharp
// Add this method to your Form1 class or a separate static class

public static void ProcessArray(int[] numbers)
{
    int index = 0;

    while (index < numbers.Length)
    {
        int current = numbers[index];

        // Skip negative numbers using continue
        if (current < 0)
        {
            Console.WriteLine($"Skipping negative number: {current}");
            index++;
            continue;
        }

        // Stop processing if we encounter 0 (sentinel value)
        if (current == 0)
        {
            Console.WriteLine("Zero encountered. Stopping processing.");
            break;
        }

        // Process valid positive numbers
        Console.WriteLine($"Processing: {current}");

        if (current % 3 == 0)
            Console.WriteLine($"  --> {current} is divisible by 3");

        index++;
    }

    Console.WriteLine("Processing complete.");
}
```

### 🧪 Test It (in a button click or Main method)

```csharp
int[] testArray = { 9, -3, 6, 0, 15, 7, -1, 12 };
ProcessArray(testArray);

// Expected output:
// Processing: 9   --> divisible by 3
// Skipping negative number: -3
// Processing: 6   --> divisible by 3
// Zero encountered. Stopping processing.
// Processing complete.
```

### ▶️ How to Run
1. Add `ProcessArray()` to your `Form1.cs` or a `static class Helpers`
2. Call it from a button click or the form's constructor
3. View output in **Debug Output** window (View → Output), or add a `MessageBox` / `Console.WriteLine`

---

## C) SQL Server, DataGridView & LINQ

### 📌 What It Does
- Connects to SQL Server
- Retrieves the `Products` table and shows it in a `DataGridView`
- Parameterized Insert, Update, Delete with exception handling
- LINQ query for products with price > 100

### ⚙️ Setup
1. Install NuGet: `System.Data.SqlClient` (right-click project → Manage NuGet Packages)
2. Create a `Products` table in SQL Server:

```sql
CREATE TABLE Products (
    ProductID   INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(100),
    Price       DECIMAL(10,2),
    Stock       INT
);

INSERT INTO Products VALUES ('Laptop', 999.99, 15);
INSERT INTO Products VALUES ('Mouse', 25.00, 100);
INSERT INTO Products VALUES ('Monitor', 350.00, 30);
INSERT INTO Products VALUES ('Keyboard', 75.00, 60);
```

### 💻 Code — `Form1.cs`

```csharp
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

public partial class Form1 : Form
{
    // ⚠️ Update this connection string to match your SQL Server
    private string connStr = @"Server=.\SQLEXPRESS;Database=YourDatabase;Integrated Security=True;";

    public Form1()
    {
        InitializeComponent();
        LoadProducts();
    }

    // ---- Load Products into DataGridView ----
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
            MessageBox.Show("Error loading: " + ex.Message);
        }
    }

    // ---- i. Parameterized INSERT ----
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

    // ---- i. Parameterized UPDATE ----
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
    }

    // ---- i. Parameterized DELETE ----
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
    }

    // ---- ii. LINQ Query ----
    private void btnLinq_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Products");

                // LINQ query on DataTable
                var expensiveProducts = ds.Tables["Products"].AsEnumerable()
                    .Where(row => row.Field<decimal>("Price") > 100)
                    .Select(row => new {
                        Name  = row.Field<string>("ProductName"),
                        Price = row.Field<decimal>("Price")
                    });

                int count = expensiveProducts.Count();
                double avg = expensiveProducts.Average(p => (double)p.Price);

                MessageBox.Show($"Products > $100:\nCount: {count}\nAverage Price: ${avg:F2}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("LINQ error: " + ex.Message);
        }
    }
}
```

### 📖 Advantages of LINQ
> **LINQ (Language Integrated Query)** gives these key benefits:
> - **Type-safe** — errors caught at compile time, not runtime
> - **Readable** — SQL-like syntax directly in C# code
> - **Works on any collection** — arrays, lists, DataTables, XML, databases
> - **IntelliSense support** — IDE autocomplete works on queries
> - **Less boilerplate** — replaces manual loops with clean one-liners

### ▶️ How to Run
1. Create project `QuestionC`, add a `DataGridView`, 3 Buttons (Insert/Update/Delete/LINQ), and 3 TextBoxes (Name, Price, Stock)
2. Update the `connStr` with your SQL Server instance name
3. Run the SQL `CREATE TABLE` script in SSMS first
4. Press **F5**, load products, test CRUD and LINQ buttons

---

## D) Student Scores & Custom Exception

### 📌 What It Does
- Form with StudentName, Test1, Test2 TextBoxes, Calculate Button, Average Label, PassedStudents ListBox
- `Student` class with properties, `CalculateAverage()`, `HasPassed()`
- Custom exception for negative marks

### 💻 Code — `NegativeMarkException.cs` (new file)

```csharp
using System;

public class NegativeMarkException : Exception
{
    public NegativeMarkException(string fieldName, int value)
        : base($"Invalid mark in '{fieldName}': {value}. Marks cannot be negative.")
    {
    }
}
```

### 💻 Code — `Student.cs` (new file)

```csharp
public class Student
{
    // Private fields
    private string _name;
    private int _test1;
    private int _test2;

    // Properties with validation
    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Name cannot be empty.")
            : value;
    }

    public int Test1
    {
        get => _test1;
        set
        {
            if (value < 0) throw new NegativeMarkException("Test1", value);
            _test1 = value;
        }
    }

    public int Test2
    {
        get => _test2;
        set
        {
            if (value < 0) throw new NegativeMarkException("Test2", value);
            _test2 = value;
        }
    }

    // Constructor
    public Student(string name, int test1, int test2)
    {
        Name  = name;
        Test1 = test1;
        Test2 = test2;
    }

    // Methods
    public double CalculateAverage() => (_test1 + _test2) / 2.0;

    public bool HasPassed() => CalculateAverage() >= 50;
}
```

### 💻 Code — `Form1.cs`

```csharp
using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1() { InitializeComponent(); }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        try
        {
            // Parse inputs
            string name = txtStudentName.Text.Trim();
            int test1   = int.Parse(txtTest1.Text);
            int test2   = int.Parse(txtTest2.Text);

            // Instantiate Student (may throw NegativeMarkException)
            Student s = new Student(name, test1, test2);

            // Display average
            double avg = s.CalculateAverage();
            lblAverage.Text = $"Average: {avg:F1}";

            // Update ListBox if passed
            if (s.HasPassed())
            {
                if (!lstPassedStudents.Items.Contains(s.Name))
                    lstPassedStudents.Items.Add(s.Name);
            }
            else
            {
                MessageBox.Show($"{s.Name} did not pass (Average: {avg:F1})");
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
    }
}
```

### 📖 Why Exception Handling Matters in Event-Driven Apps
> In event-driven applications, **code runs in response to user actions** (button clicks, key presses). Without exception handling:
> - A single invalid input crashes the **entire application**
> - Users get confusing system error messages
> - The UI becomes unresponsive or freezes
>
> With proper exception handling, you can **gracefully recover**, show user-friendly messages, and keep the app running safely.

### ▶️ How to Run
1. Create project `QuestionD`
2. Add 3 files: `NegativeMarkException.cs`, `Student.cs`, `Form1.cs`
3. Design form: TextBoxes (StudentName, Test1, Test2), Button (Calculate), Label (Average), ListBox (PassedStudents)
4. Press **F5** → test with valid marks, then test with `-5` to trigger the custom exception

---

## E) BankAccount Class

### 📌 What It Does
- Robust `BankAccount` class with Deposit, Withdraw, and Validation
- All transactions saved to a file
- Transactions displayed in a `ListBox`

### 💻 Code — `BankAccount.cs`

```csharp
using System;
using System.IO;

public class BankAccount
{
    private string _owner;
    private decimal _balance;
    private string _logFile = "transactions.txt";

    public string Owner   => _owner;
    public decimal Balance => _balance;

    public BankAccount(string owner, decimal initialBalance)
    {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Owner name cannot be empty.");
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");

        _owner   = owner;
        _balance = initialBalance;
        Log($"Account created for {owner}. Initial balance: {initialBalance:C}");
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");

        _balance += amount;
        Log($"DEPOSIT: {amount:C} | New Balance: {_balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > _balance)
            throw new InvalidOperationException($"Insufficient funds. Balance: {_balance:C}, Requested: {amount:C}");

        _balance -= amount;
        Log($"WITHDRAWAL: {amount:C} | New Balance: {_balance:C}");
    }

    private void Log(string message)
    {
        string entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
        File.AppendAllText(_logFile, entry + Environment.NewLine);
    }

    public string[] GetTransactions()
    {
        return File.Exists(_logFile) ? File.ReadAllLines(_logFile) : Array.Empty<string>();
    }
}
```

### 💻 Code — `Form1.cs`

```csharp
using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private BankAccount account;

    public Form1()
    {
        InitializeComponent();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            account = new BankAccount(txtOwner.Text, decimal.Parse(txtAmount.Text));
            RefreshDisplay();
            MessageBox.Show("Account created!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void btnDeposit_Click(object sender, EventArgs e)
    {
        try
        {
            account.Deposit(decimal.Parse(txtAmount.Text));
            RefreshDisplay();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Deposit failed: " + ex.Message);
        }
    }

    private void btnWithdraw_Click(object sender, EventArgs e)
    {
        try
        {
            account.Withdraw(decimal.Parse(txtAmount.Text));
            RefreshDisplay();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show("Withdrawal failed: " + ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void RefreshDisplay()
    {
        lblBalance.Text = $"Balance: {account.Balance:C}";
        lstTransactions.Items.Clear();
        foreach (string line in account.GetTransactions())
            lstTransactions.Items.Add(line);
    }
}
```

### ▶️ How to Run
1. Create project `QuestionE`
2. Add `BankAccount.cs` and update `Form1.cs`
3. Design form: TextBoxes (Owner, Amount), Buttons (Create, Deposit, Withdraw), Label (Balance), ListBox (Transactions)
4. Press **F5**, create an account, test deposits and withdrawals including invalid ones
5. Check `transactions.txt` in `bin/Debug`

---

## F) Power Method with Ref Parameters

### 📌 What It Does
- `Power(int x, int y)` using iterative multiplication (no `Math.Pow`)
- Throws exception if `y < 0`
- Demonstrates `ref` parameter usage

### 💻 Code — Add to `Form1.cs` or a helper class

```csharp
using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1() { InitializeComponent(); }

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
            DoubleIt(ref sample);
            lblRefDemo.Text = $"ref demo: 5 → {sample}"; // shows 10
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show("Power error: " + ex.Message);
        }
        catch (FormatException)
        {
            MessageBox.Show("Enter valid integer values.");
        }
    }
}
```

### 📖 Ref Parameters — Quick Explanation
> `ref` passes a variable **by reference** instead of by value.  
> Without `ref`: the method gets a **copy** — changes don't affect the original.  
> With `ref`: the method works on the **original variable** — changes persist after the call.

### ▶️ How to Run
1. Create project `QuestionF`
2. Add 2 TextBoxes (Base, Exponent), a Button, and 2 Labels (Result, Ref Demo)
3. Paste the code above
4. Press **F5** → try `2^10` (should give 1024), then try `2^-1` to trigger the exception

---

## G) Event-Driven UI — CheckedListBox, DateTimePicker, TreeView & LinkLabel

### 📌 What It Does
- `CheckedListBox` — user selects multiple items
- `DateTimePicker` — picks a date/time
- `TreeView` — displays selected items grouped by date
- `LinkLabel` — clickable link that opens a URL

### 💻 Code — `Form1.cs`

```csharp
using System;
using System.Diagnostics;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
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
                if (child.Text == subject) { exists = true; break; }

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
        Process.Start(new ProcessStartInfo("https://learn.microsoft.com/en-us/dotnet/")
        {
            UseShellExecute = true
        });
    }

    // ---- TreeView: Show selected node info ----
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        lblStatus.Text = $"Selected: {e.Node.Text}";
    }
}
```

### 🪟 Form Design Guide
| Control | Name | Properties |
|---|---|---|
| `CheckedListBox` | `checkedListBox1` | MultiColumn = false |
| `DateTimePicker` | `dateTimePicker1` | Format = Long |
| `TreeView` | `treeView1` | ShowLines = true |
| `LinkLabel` | `linkLabel1` | Text = "Microsoft .NET Docs" |
| `Button` | `btnAdd` | Text = "Add to Schedule" |
| `Label` | `lblStatus` | Text = "" |

### ▶️ How to Run
1. Create project `QuestionG`
2. Design the form using the table above (drag-drop from Toolbox)
3. Double-click each control to auto-generate event handlers, then paste the matching code
4. Press **F5**
5. Check some subjects, pick a date, click **Add to Schedule** — items appear in the TreeView grouped by date
6. Click the LinkLabel to open the .NET documentation in your browser

---

## 🧰 General Tips for All Questions

| Tip | Detail |
|---|---|
| **Build before run** | Press `Ctrl+Shift+B` to build, then `F5` to run |
| **Breakpoints** | Click left margin to set breakpoints for debugging |
| **Output window** | View → Output to see `Console.WriteLine` messages |
| **NuGet packages** | Right-click project → Manage NuGet Packages |
| **Connection strings** | Always update SQL Server name in `connStr` before running Question C |
| **File paths** | Text files save to `bin\Debug\net*\` by default |
| **Exception testing** | Intentionally enter bad values to verify your exception handling works |

---

*Generated for Visual Programming Assignment 2 — Zimbabwe / Southern Africa curriculum*