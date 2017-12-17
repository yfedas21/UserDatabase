using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserDatabase
{
    class Student
    {
        string firstName, lastName, major;
        int year;

        public Student()
        {

        }

        public Student(string firstName, string lastName, string major, int year)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.major = major;
            this.year = year;
        }
    }
}
