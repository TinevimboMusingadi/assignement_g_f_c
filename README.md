# Visual Programming Assignment 2 - Complete Solution

This repository contains the complete solution for Visual Programming Assignment 2. All questions (A through G) are integrated into a single Windows Forms application with a central dashboard for easy navigation.

## 🚀 How to Run in Visual Studio

1.  **Clone the Repository**:
    ```bash
    git clone https://github.com/TinevimboMusingadi/visual-assignment2.git
    ```
2.  **Open the Project**:
    *   Launch **Visual Studio 2022** (or later).
    *   Go to `File` -> `Open` -> `Project/Solution`.
    *   Select `Assignment.slnx` or `Assignment.csproj` from the project folder.
3.  **Restore Packages**:
    *   Visual Studio usually does this automatically. If not, right-click the **Solution** in Solution Explorer and select **Restore NuGet Packages**.
4.  **Launch the Application**:
    *   Press **F5** or click the **Start (Assignment)** button at the top.
    *   The **Assignment Dashboard** will open.

---

## 🖥️ Question-by-Question Navigation

When the application runs, you will see a main menu. Here is how to test each question:

### Question A: Arrays & File I/O
- Click **"Question A - Arrays"**.
- Enter 8 integers in the boxes.
- Click **Process**. It will calculate the max, check divisibility by 3, and save to `numbers.txt`.

### Question B: Loops (Break/Continue)
- Click **"Question B - Loops"**.
- Click **Run While Loop Test**. 
- View the output in the text area to see how negatives are skipped and zero stops the loop.

### Question C: MySQL & LINQ

**Course handout mapping (behaviour)** — Question C demonstrates:

1. Database connection (handout uses SQL Server **`SqlClient`**; this solution uses **`MySqlConnector`** against **MySQL 8.x** instead).
2. **`Products`** bound to a **`DataGridView`** (loads automatically when the form opens if the DB exists).
3. **Parameterized INSERT / UPDATE / DELETE** with **`try`/`catch`** (`FormatException`, **`MySqlException`**).
4. **LINQ** over a **`DataTable`** filled by **`SELECT *`** (`Price > 100`, **count**, **average**) — **`LINQ Analyze`** re-queries like the sample pattern.

**Stack note:** markers who require **`System.Data.SqlClient`** verbatim should ask for that edition; behaviour here matches the handout aside from DB engine.

- Click **"Question C - SQL/LINQ"**.
- Question C uses NuGet **`MySqlConnector`** and MySQL (**127.0.0.1**, port **3306**, **`root`**). Ensure **`MySQL80`** is **running**.
- **`Forms/QuestionCForm.cs`** — edit **`MySqlHost`** / **`MySqlPassword`** / **`MySqlDatabase`** if needed.
- **First run**: **Setup DB** (creates **`assignmentdb`**, **`Products`**, seeds rows), then use **Refresh Data** if you prefer; the grid also loads on open after the DB exists.
- **Or** run [`Scripts/SetupAssignmentDB_MySQL.sql`](Scripts/SetupAssignmentDB_MySQL.sql) in MySQL Workbench.
### Question D: Students & Exceptions
- Click **"Question D - Student"**.
- Enter a name and marks.
- **Trigger Exception**: Enter a negative mark (e.g., `-5`) and click Calculate to see the custom `NegativeMarkException` in action.

### Question E: Bank Account
- Click **"Question E - Bank"**.
- Create an account first, then perform Deposits and Withdrawals.
- Check the ListBox for a live transaction history.

### Question F: Power & Ref
- Click **"Question F - Power"**.
- Calculate `x^y`.
- Note the `ref demo` label which shows how a value was changed directly by a method using the `ref` keyword.

### Question G: UI Controls
- Click **"Question G - UI Controls"**.
- Check multiple subjects, pick a date, and click **Add to Schedule**.
- Observe the **TreeView** grouping your selections by date.

---

## 📝 Technical Details
- **IDE**: Visual Studio
- **Language**: C#
- **Framework**: .NET (Windows Forms)
- **Database Library (Question C)**: `MySqlConnector` (MySQL 8.x)

*Developed by Tinevimbo Musingadi and TEAM*
