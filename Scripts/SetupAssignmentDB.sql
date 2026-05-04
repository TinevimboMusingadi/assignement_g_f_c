-- Run in SQL Server Management Studio (SSMS) or sqlcmd against your instance.
-- Use the same Server= value as in the app connection string:
--   (localdb)\MSSQLLocalDB   OR   .\SQLEXPRESS   etc.

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'AssignmentDB')
BEGIN
    CREATE DATABASE AssignmentDB;
END
GO

USE AssignmentDB;
GO

IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products (
        ProductID   INT PRIMARY KEY IDENTITY,
        ProductName NVARCHAR(100),
        Price       DECIMAL(10, 2),
        Stock       INT
    );

    INSERT INTO dbo.Products (ProductName, Price, Stock)
    VALUES (N'Laptop', 999.99, 15),
           (N'Mouse', 25.00, 100),
           (N'Monitor', 350.00, 30),
           (N'Keyboard', 75.00, 60);
END
GO
