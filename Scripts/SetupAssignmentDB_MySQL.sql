-- Run in MySQL Workbench connected as root (or mysql CLI).
-- Matches Workbench defaults: localhost / 3306.

CREATE DATABASE IF NOT EXISTS assignmentdb;
USE assignmentdb;

CREATE TABLE IF NOT EXISTS Products (
    ProductID INT NOT NULL AUTO_INCREMENT,
    ProductName VARCHAR(100) NULL,
    Price DECIMAL(10, 2) NULL,
    Stock INT NULL,
    PRIMARY KEY (ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO Products (ProductName, Price, Stock)
SELECT * FROM (
    SELECT 'Laptop' AS ProductName, CAST(999.99 AS DECIMAL(10,2)) AS Price, 15 AS Stock
    UNION ALL SELECT 'Mouse', 25.00, 100
    UNION ALL SELECT 'Monitor', 350.00, 30
    UNION ALL SELECT 'Keyboard', 75.00, 60
) AS seed
WHERE NOT EXISTS (SELECT 1 FROM Products LIMIT 1);
