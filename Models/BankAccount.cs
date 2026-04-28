using System;
using System.IO;
using System.Collections.Generic;

namespace Assignment.Models
{
    public class BankAccount
    {
        private string _owner;
        private decimal _balance;
        private string _logFile = "transactions.txt";

        public string Owner => _owner;
        public decimal Balance => _balance;

        public BankAccount(string owner, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(owner))
                throw new ArgumentException("Owner name cannot be empty.");
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            _owner = owner;
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
            try
            {
                File.AppendAllText(_logFile, entry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // In a real app, we'd handle this better
                Console.WriteLine("Logging failed: " + ex.Message);
            }
        }

        public string[] GetTransactions()
        {
            try
            {
                return File.Exists(_logFile) ? File.ReadAllLines(_logFile) : new string[0];
            }
            catch
            {
                return new string[] { "Error reading transactions." };
            }
        }
    }
}
