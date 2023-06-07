using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_wash_console_app
{
    internal class People
    {
        public int Id { get; set; }

        private static int NextId = 1;
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public People(string name, string docNumber)
        {
            this.Name = name;
            this.DocumentNumber = docNumber;
            Id = NextId;
            NextId++;
        }
    }

    internal class Employee : People 
    {
        public double Salary { get; set; }
        public bool WorkingNow { get; set; }

        public Employee(string name, string docNumber, double salary) : base(name, docNumber)
        {
            this.Salary = salary;
            this.WorkingNow = false;
        }
    }
}
