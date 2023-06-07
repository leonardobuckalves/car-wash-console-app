using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace car_wash_console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            bool runProgram = true;

            while (runProgram)
            {
                MainOptions();
            }

            void CreateLine()
            {
                Console.WriteLine("================================================================\n");
            }

            void ShowTitle()
            {
                string title = "Car Wash App\n";
                Console.Clear();
                CreateLine();
                Console.WriteLine(title);
                CreateLine();
            }

            void MainOptions()
            {
                //ShowTitle();

                Console.WriteLine("Options:");
                Console.WriteLine("\n1 - Add Service");
                Console.WriteLine("2 - Add Car");
                Console.WriteLine("3 - Add Client");
                Console.WriteLine("4 - Add Employee");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("\nWrite the option number to choose it: ");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.Clear();
                    WashSelection();
                }

                else if (userInput == "2")
                {
                    //create, edit, delete????
                    //CreateCar();
                }

                else if (userInput == "3")
                {
                    //create, edit, delete????
                    //CreateClient();
                }

                else if (userInput == "4")
                {
                    //create, edit, delete????
                    Console.Clear();
                    CreateEmployee();
                }

                else if (userInput == "5")
                {
                    ExitProgram();
                }

                else
                {
                    InvalidChoiceErrorMessage();
                }
            }

            void InvalidChoiceErrorMessage()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid option...");
                Console.ResetColor();
            }

            void WashSelection()
            {
                CreateLine();
                Console.WriteLine("\nChoose the service");
                Console.WriteLine("\n1 - Fast Wash");
                Console.WriteLine("2 - Long Wash");
                Console.WriteLine("3 - Especial Wash");
                Console.WriteLine("\nWrite the option number to choose it: ");
                string serviceOption = Console.ReadLine();

                if (serviceOption == "1")
                {
                    Console.WriteLine("\nFast Wash selected. Confirm? (Yes/No)");
                    string confirmation = Console.ReadLine().ToLower().Trim();

                    if (confirmation == "yes")
                    {
                        WashServices washServices = new WashServices(WashServices.WashType.Fast);
                        Console.WriteLine("Choose the available employee");
                        
                        foreach (Employee employee in employees)
                        {
                            if (!employee.WorkingNow)
                            {
                                Console.WriteLine($"{employee.Id}, {employee.Name}");
                            }
                        }

                        int selectedEmployeeNum = int.Parse(Console.ReadLine());

                        foreach (Employee employee in employees)
                        {
                            if (selectedEmployeeNum == employee.Id)
                            {
                                washServices.StartWash(employee);
                                Console.WriteLine(employee.WorkingNow);
                                //Start timer
                            }
                        }
                    }

                    else if (confirmation == "no")
                    {
                        Console.WriteLine("Returning to main menu");
                    }

                    else
                    {
                        InvalidChoiceErrorMessage();
                    }
                }
                else if (serviceOption == "2")
                {
                    Console.WriteLine("Long Wash selected. Confirm? (Yes/No)");
                    string confirmation = Console.ReadLine();
                    confirmation.ToLower().Trim();

                    if (confirmation == "yes")
                    {
                        WashServices washServices = new WashServices(WashServices.WashType.Long);
                        Console.WriteLine("Choose the available employee");
                        //Choose employee and start a x sec timer
                    }
                    else
                    {
                        InvalidChoiceErrorMessage();
                    }
                }
                else if (serviceOption == "3")
                {
                    Console.WriteLine("Especial Wash selected. Confirm? (Yes/No)");
                    string confirmation = Console.ReadLine();
                    confirmation.ToLower().Trim();

                    if (confirmation == "yes")
                    {
                        WashServices washServices = new WashServices(WashServices.WashType.Especial);
                        Console.WriteLine("Choose the available employee");
                        //Choose employee and start a x sec timer
                    }
                    else
                    {
                        InvalidChoiceErrorMessage();
                    }
                }
                else
                {
                    InvalidChoiceErrorMessage();
                }
            }

            void CreateEmployee()
            {
                Console.WriteLine("What is the employee's name?");
                string newEmployeeName = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("What is the employee's salary");
                double newEmployeeSalary = double.Parse(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("What is the employee's document number");
                string newEmployeeDocNumber = Console.ReadLine();

                Console.Clear();
                Console.WriteLine($"New employee file:");
                Console.WriteLine($"\nName: {newEmployeeName}.");
                Console.WriteLine($"Salary: {newEmployeeSalary}.");
                Console.WriteLine($"document number: {newEmployeeDocNumber}.");
                //Console.WriteLine($"Confirm? (Yes/No)");
                // if no, change wich one?
                //Console.ReadLine();
                Employee newEmployee = new Employee(newEmployeeName, newEmployeeDocNumber, newEmployeeSalary);
                employees.Add(newEmployee);
                
            }

            void ExitProgram()
            {
                runProgram = false;
            }
        }
    }
}
