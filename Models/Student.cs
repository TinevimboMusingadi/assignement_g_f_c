using System;
using Assignment.Exceptions;

namespace Assignment.Models
{
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
            Name = name;
            Test1 = test1;
            Test2 = test2;
        }

        // Methods
        public double CalculateAverage() => (_test1 + _test2) / 2.0;

        public bool HasPassed() => CalculateAverage() >= 50;
    }
}
