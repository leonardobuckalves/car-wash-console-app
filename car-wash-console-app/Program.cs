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
                }
                else if (serviceOption == "2")
                {
                    Console.WriteLine("Long wash selected.\n");
                    WashServices washServices = new WashServices(WashServices.WashType.Long);
                    Employee selectedEmployee = SelectEmployeeForWash();
                    Vehicle selectedCar = SelectCarForWash();
                    washServices.StartWash(selectedEmployee, selectedCar);
                }
                else if (serviceOption == "3")
                {
                    Console.WriteLine("Especial wash selected.\n");
                    WashServices washServices = new WashServices(WashServices.WashType.Especial);
                    Employee selectedEmployee = SelectEmployeeForWash();
                    Vehicle selectedCar = SelectCarForWash();
                    washServices.StartWash(selectedEmployee, selectedCar);
                }
                else
                {
                    InvalidChoiceErrorMessage();
                }
            }

            void CreateCar() 
            {
                Console.WriteLine("What is the car plate number");
                string newCarPlateNumber = Console.ReadLine();

                Console.WriteLine("What is the car color");
                string newCarColor = Console.ReadLine();

                Console.WriteLine("What is the car Model");
                string newCarModel = Console.ReadLine();

                Console.WriteLine("Who is the owner?");
                foreach (Client client in clients)
                {
                    Console.WriteLine($"Id: {client.Id} - Name: {client.Name}");
                }
                int newCarOwnerId = int.Parse( Console.ReadLine() );

                foreach (Client client in clients)
                {
                    if (client.Id == newCarOwnerId)
                    {
                        Vehicle newVehicle = new Vehicle(newCarPlateNumber, newCarColor, newCarModel, client);
                        client.Vehicles.Add(newVehicle);
                    }
                }
            }

            void CreateClient()
            {
                Console.WriteLine("What is the client's name?");
                string newClientName = Console.ReadLine();

                Console.WriteLine("What is the client's document number");
                string newClientDocNumber = Console.ReadLine();

                Client newClient = new Client(newClientName, newClientDocNumber);
                clients.Add(newClient);
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
                Console.WriteLine($"Confirm? (Yes/No)");
                // if no, change wich one?
                string choiceConfirmed = Console.ReadLine().ToLower().Trim();
                if (choiceConfirmed == "yes")
                {
                    Employee newEmployee = new Employee(newEmployeeName, newEmployeeDocNumber, newEmployeeSalary);
                    employees.Add(newEmployee);
                }
                
            }

            Employee SelectEmployeeForWash()
            {
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
                    if(selectedEmployeeNum == employee.Id)
                    {
                        return employee;
                    }
                }

                return null;
            }

            Vehicle SelectCarForWash()
            {
                Console.WriteLine("Select the client");
                foreach (Client client in clients)
                {
                    Console.WriteLine($"Client ID: {client.Id}");
                    Console.WriteLine($"Client Name: {client.Name}");
                }

                int clientSelected = int.Parse(Console.ReadLine());
                
                foreach (Client client in clients)
                {
                    if (clientSelected == client.Id)
                    {
                        Console.WriteLine("Select the car");
                        foreach (Vehicle vehicle in client.Vehicles)
                        {
                            Console.WriteLine($"Car Id: {vehicle.Id}");
                            Console.WriteLine($"Car Model: {vehicle.Model}");
                            Console.WriteLine($"Car plate: {vehicle.PlateNumber}");
                        }
                        int carSelected = int.Parse(Console.ReadLine());
                        
                        foreach(Vehicle vehicle in client.Vehicles)
                        {
                            if(carSelected == vehicle.Id)
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
