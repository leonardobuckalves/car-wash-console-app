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
        public string Name { get; set; }
        public string Adress { get; set; }
        public People(string name, string adress)
        {
            this.Name = name;
            this.Adress = adress;
        }
    }

    class Employee : People 
    {
        public double Salary { get; set; }
        public bool WorkingNow { get; set; }

        public Employee(string name, string adress, double salary) : base(name, adress)
        {
            this.Salary = salary;
            this.WorkingNow = false;
        }
    }
}
