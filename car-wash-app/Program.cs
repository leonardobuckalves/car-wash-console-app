using car_wash_app;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace car_wash_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Client> clients = new List<Client>();

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
                ShowTitle();

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
                    Console.Clear();
                    CreateCar();
                }

                else if (userInput == "3")
                {
                    //create, edit, delete????
                    Console.Clear();
                    CreateClient();
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
                Console.WriteLine("Choose the service");
                Console.WriteLine("\n1 - Fast Wash");
                Console.WriteLine("2 - Long Wash");
                Console.WriteLine("3 - Especial Wash");
                Console.WriteLine("\nWrite the option number to choose it: ");
                string serviceOption = Console.ReadLine();

                if (serviceOption == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Fast wash selected.\n");
                    WashServices washServices = new WashServices(WashServices.WashType.Fast);
                    Employee selectedEmployee = SelectEmployeeForWash();
                    Vehicle selectedCar = SelectCarForWash();
                    washServices.StartWash(selectedEmployee, selectedCar);
                    WashInProgressText();
                }
                else if (serviceOption == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Long wash selected.\n");
                    WashServices washServices = new WashServices(WashServices.WashType.Long);
                    Employee selectedEmployee = SelectEmployeeForWash();
                    Vehicle selectedCar = SelectCarForWash();
                    washServices.StartWash(selectedEmployee, selectedCar);
                    WashInProgressText();
                }
                else if (serviceOption == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Especial wash selected.\n");
                    WashServices washServices = new WashServices(WashServices.WashType.Especial);
                    Employee selectedEmployee = SelectEmployeeForWash();
                    Vehicle selectedCar = SelectCarForWash();
                    washServices.StartWash(selectedEmployee, selectedCar);
                    WashInProgressText();
                }
                else
                {
                    InvalidChoiceErrorMessage();
                }
            }

            void WashInProgressText()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\nWash in progress...");
                Console.ResetColor();
                Thread.Sleep(3000);
            }

            void CreateCar()
            {
                Console.Clear();
                Console.WriteLine("What is the car plate number");
                string newCarPlateNumber = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("What is the car color");
                string newCarColor = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("What is the car Model");
                string newCarModel = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Who is the owner?");
                foreach (Client client in clients)
                {
                    Console.WriteLine($"Id: {client.Id} - Name: {client.Name}");
                }
                int newCarOwnerId = int.Parse(Console.ReadLine());

                foreach (Client client in clients)
                {
                    if (client.Id == newCarOwnerId)
                    {
                        Console.Clear();
                        Console.WriteLine($"New car file:");
                        Console.WriteLine($"\nPlate: {newCarPlateNumber}.");
                        Console.WriteLine($"Color: {newCarColor}.");
                        Console.WriteLine($"Car model: {newCarModel}.");
                        Console.WriteLine($"\nConfirm? (Yes/No)");
                        // if no, change wich one?
                        string choiceConfirmed = Console.ReadLine().ToLower().Trim();
                        if (choiceConfirmed == "yes")
                        {
                            Vehicle newVehicle = new Vehicle(newCarPlateNumber, newCarColor, newCarModel, client);
                            client.Vehicles.Add(newVehicle);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nCar created sucessfully");
                            Console.ResetColor();
                            Thread.Sleep(3000);
                        }
                    }
                }    
            }

            void CreateClient()
            {
                Console.Clear();
                Console.WriteLine("What is the client's name?");
                string newClientName = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("What is the client's document number");
                string newClientDocNumber = Console.ReadLine();

                Console.Clear();
                Console.WriteLine($"New client file:");
                Console.WriteLine($"\nName: {newClientName}.");
                Console.WriteLine($"Document number: {newClientDocNumber}.");
                Console.WriteLine($"\nConfirm? (Yes/No)");
                // if no, change wich one?
                string choiceConfirmed = Console.ReadLine().ToLower().Trim();
                if (choiceConfirmed == "yes")
                {
                    Client newClient = new Client(newClientName, newClientDocNumber);
                    clients.Add(newClient);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nClient created sucessfully");
                    Console.ResetColor();
                    Thread.Sleep(3000);
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
                Console.WriteLine($"Document number: {newEmployeeDocNumber}.");
                Console.WriteLine($"\nConfirm? (Yes/No)");
                // if no, change wich one?
                string choiceConfirmed = Console.ReadLine().ToLower().Trim();
                if (choiceConfirmed == "yes")
                {
                    Employee newEmployee = new Employee(newEmployeeName, newEmployeeDocNumber, newEmployeeSalary);
                    employees.Add(newEmployee);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nEmployee created sucessfully");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                }
            }

            Employee SelectEmployeeForWash()
            {
                Console.Clear();
                Console.WriteLine("Choose the available employee:");

                foreach (Employee employee in employees)
                {
                    if (!employee.WorkingNow)
                    {
                        Console.WriteLine($"{employee.Id} - {employee.Name}");
                    }
                }

                int selectedEmployeeNum = int.Parse(Console.ReadLine());

                foreach (Employee employee in employees)
                {
                    if (selectedEmployeeNum == employee.Id)
                    {
                        return employee;
                    }
                }

                return null;
            }

            Vehicle SelectCarForWash()
            {
                Console.Clear();
                Console.WriteLine("Select the client");
                foreach (Client client in clients)
                {
                    Console.WriteLine($"Client ID: {client.Id}, Name: {client.Name}");
                }

                int clientSelected = int.Parse(Console.ReadLine());

                foreach (Client client in clients)
                {
                    if (clientSelected == client.Id)
                    {
                        Console.WriteLine("\nSelect the car");
                        foreach (Vehicle vehicle in client.Vehicles)
                        {
                            Console.WriteLine($"Car Id: {vehicle.Id}, Model: {vehicle.Model}, Plate: {vehicle.PlateNumber}");
                        }
                        int carSelected = int.Parse(Console.ReadLine());

                        foreach (Vehicle vehicle in client.Vehicles)
                        {
                            if (carSelected == vehicle.Id)
                            {
                                return vehicle;
                            }
                        }
                    }
                }
                return null;
            }

            void ExitProgram()
            {
                runProgram = false;
            }
        }
    }
}
