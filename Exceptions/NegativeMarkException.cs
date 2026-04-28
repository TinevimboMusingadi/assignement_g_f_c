using System;

namespace Assignment.Exceptions
{
    public class NegativeMarkException : Exception
    {
        public NegativeMarkException(string fieldName, int value)
            : base($"Invalid mark in '{fieldName}': {value}. Marks cannot be negative.")
        {
        }
    }
}
