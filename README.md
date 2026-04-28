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

### Question C: SQL & LINQ
- Click **"Question C - SQL/LINQ"**.
- **Setup Required**: Ensure you have SQL Server installed and a database named `AssignmentDB` with a `Products` table (see the SQL script in the code comments).
- Test Insert, Update, Delete, and the **LINQ** button to filter products > $100.

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
- **Database Library**: `System.Data.SqlClient`

*Developed by Tinevimbo Musingadi and TEAM*
