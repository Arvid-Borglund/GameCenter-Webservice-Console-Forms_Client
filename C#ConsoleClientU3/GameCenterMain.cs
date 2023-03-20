using System;
using System.Collections.Generic;
using System.Linq;





public class Program
{
    static void Main(string[] args)
    {
	Console.Clear();
        WebServiceGameCenter proxy = new WebServiceGameCenter();
        bool quit = false;
	// proxy.TryErrorHandling();
        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine();
      	    Console.WriteLine();
	    Console.WriteLine();
            Console.WriteLine("                                     * * *      ******* ");
            Console.WriteLine("                                   * ^^    * ********          *****");
            Console.WriteLine("                                  *O           *********  ******");
            Console.WriteLine("    !!Welcome to Game Center!!    >---                    ** ");
            Console.WriteLine("                                   * * * ***     *******   *******");
            Console.WriteLine("                                           ** * *         ******");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter your login ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string loginPassword = Console.ReadLine();
            Console.WriteLine();

            string role;
            // Verify the credentials
            if (proxy.VerifyCredentials(id, loginPassword, out role))
            {
			
		if(role != "Admin" && role != "Employee")
            	{
                Console.WriteLine("Only employees may use this application!");
		Console.WriteLine();
		Console.WriteLine();
		break;
            	}

                Console.WriteLine("Password and username is correct, these are your table options:");
                Console.WriteLine("Employee, Customer, Computer, Game, Login");
                Console.WriteLine();
                string selectedEntityCon = "";
                bool validSelection = false;
                while (!validSelection)
                {
                    Console.WriteLine("Enter the table you want to access:");
                    selectedEntityCon = Console.ReadLine();
                    Console.WriteLine();

                    if (selectedEntityCon == "Employee" || selectedEntityCon == "Customer" || selectedEntityCon == "Computer" || selectedEntityCon == "Game" || selectedEntityCon == "Login")
                    {
                        validSelection = true;
                    }
                    else
                    {
                        Console.WriteLine("There is no such table. Try again.");
                    }
                }

                string result = proxy.GetSelectedEntityData(selectedEntityCon, role);
                Console.WriteLine(result);
                Console.WriteLine();
		Console.WriteLine(proxy.GetErrorMessage());

                bool success = false;

                while (!success)
                {
                    Console.WriteLine();
                    Console.WriteLine("What would you like to do next?");
                    Console.WriteLine();
                    Console.WriteLine("Create, Delete, View table, logout");
                    string nextAction = Console.ReadLine();

                    if (nextAction.ToLower() == "create")
                    {
                        List<MyNamespace.MyKeyValuePairCustom> entityData = new List<MyNamespace.MyKeyValuePairCustom>();
                        Console.WriteLine();

                        if (selectedEntityCon == "Computer")
                        {
                            Console.WriteLine("Enter the values for the new computer:");
                            Console.WriteLine();
                            Console.WriteLine("ComputerId:");
                            string computerId = Console.ReadLine();
                            Console.WriteLine("Cpu:");
                            string cpu = Console.ReadLine();
                            Console.WriteLine("Gpu:");
                            string gpu = Console.ReadLine();
                            Console.WriteLine("Ram:");
                            string ram = Console.ReadLine();
                            Console.WriteLine("DataStorage:");
                            string dataStorage = Console.ReadLine();
                            Console.WriteLine();
                            List<MyNamespace.MyKeyValuePairCustom> computerData = new List<MyNamespace.MyKeyValuePairCustom>
                            {
                                new MyNamespace.MyKeyValuePairCustom("ComputerId", computerId),
                                new MyNamespace.MyKeyValuePairCustom("Cpu", cpu),
                            new MyNamespace.MyKeyValuePairCustom("Gpu", gpu),
                            new MyNamespace.MyKeyValuePairCustom("Ram", ram),
                            new MyNamespace.MyKeyValuePairCustom("DataStorage", dataStorage)
                        };

                            if (proxy.Create(computerData.Select(x => (KeyValuePairCustom)x).ToArray(), selectedEntityCon, role))
                            {
                                Console.WriteLine("Computer successfully created.");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Failed to create computer.");
				Console.WriteLine(proxy.GetErrorMessage());
                            }
                        }
                        else if (selectedEntityCon == "Employee")
                        {
                            Console.WriteLine("Enter the values for the new employee:");
                            Console.WriteLine();
                            Console.WriteLine("EmployeeId:");
                            string employeeId = Console.ReadLine();
                            Console.WriteLine("Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Address:");
                            string address = Console.ReadLine();
                            Console.WriteLine("PhoneNumber:");
                            string phoneNumber = Console.ReadLine();
                            Console.WriteLine("Email:");
                            string email = Console.ReadLine();
                            Console.WriteLine("JobTitle:");
                            string jobTitle = Console.ReadLine();
                            Console.WriteLine();
                            List<MyNamespace.MyKeyValuePairCustom> employeeData = new List<MyNamespace.MyKeyValuePairCustom>
                            {
                            new MyNamespace.MyKeyValuePairCustom("EmployeeId", employeeId),
                            new MyNamespace.MyKeyValuePairCustom("Name", name),
                            new MyNamespace.MyKeyValuePairCustom("Address", address),
                            new MyNamespace.MyKeyValuePairCustom("PhoneNumber", phoneNumber),
                            new MyNamespace.MyKeyValuePairCustom("Email", email),
                            new MyNamespace.MyKeyValuePairCustom("JobTitle", jobTitle)
                        };

                            if (proxy.Create(employeeData.Select(x => (KeyValuePairCustom)x).ToArray(), selectedEntityCon, role))
                            {
                                Console.WriteLine("Employee created successfully!");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Failed to create employee.");
				Console.WriteLine(proxy.GetErrorMessage());
                            }
                        }

                        else if (selectedEntityCon == "Customer")
                        {
                            Console.WriteLine("Enter the values for the new customer:");
                            Console.WriteLine();
                            Console.WriteLine("CustomerId:");
                            string customerId = Console.ReadLine();
                            Console.WriteLine("Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Address:");
                            string address = Console.ReadLine();
                            Console.WriteLine("PhoneNumber:");
                            string phoneNumber = Console.ReadLine();
                            Console.WriteLine("Email:");
                            string email = Console.ReadLine();
                            Console.WriteLine("LoyaltyLevel:");
                            string loyaltyLevel = Console.ReadLine();
                            Console.WriteLine();
                            List<MyNamespace.MyKeyValuePairCustom> customerData = new List<MyNamespace.MyKeyValuePairCustom>
                            {
                            new MyNamespace.MyKeyValuePairCustom("CustomerId", customerId),
                            new MyNamespace.MyKeyValuePairCustom("Name", name),
                            new MyNamespace.MyKeyValuePairCustom("Address", address),
                            new MyNamespace.MyKeyValuePairCustom("PhoneNumber", phoneNumber),
                            new MyNamespace.MyKeyValuePairCustom("Email", email),
                            new MyNamespace.MyKeyValuePairCustom("LoyaltyLevel", loyaltyLevel)
                            };

                            if (proxy.Create(customerData.Select(x => (KeyValuePairCustom)x).ToArray(), selectedEntityCon, role))
                            {
                                Console.WriteLine("Customer created successfully!");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Creation failed. Try again.");
				Console.WriteLine(proxy.GetErrorMessage());
                            }

                        }

                        else if (selectedEntityCon == "Game")
                        {
                            Console.WriteLine("Enter the values for the new game:");
                            Console.WriteLine();
                            Console.WriteLine("GameId:");
                            string gameId = Console.ReadLine();
                            Console.WriteLine("ComputerId:");
                            string computerId = Console.ReadLine();
                            Console.WriteLine("Title:");
                            string title = Console.ReadLine();
                            Console.WriteLine("Genre:");
                            string genre = Console.ReadLine();
                            Console.WriteLine();
                            List<MyNamespace.MyKeyValuePairCustom> gameData = new List<MyNamespace.MyKeyValuePairCustom>
                            {
                                new MyNamespace.MyKeyValuePairCustom("GameId", gameId),
                            new MyNamespace.MyKeyValuePairCustom("ComputerId", computerId),
                            new MyNamespace.MyKeyValuePairCustom("Title", title),
                            new MyNamespace.MyKeyValuePairCustom("Genre", genre)
                        };

                            if (proxy.Create(gameData.Select(x => (KeyValuePairCustom)x).ToArray(), selectedEntityCon, role))
                            {
                                Console.WriteLine("Game created successfully!");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Creation failed. Try again.");
				Console.WriteLine(proxy.GetErrorMessage());
                            }

                        }

                        else if (selectedEntityCon == "Login")
                        {
                            Console.WriteLine("Enter the values for the new login:");
                            Console.WriteLine();
                            Console.WriteLine("LoginId:");
                            string loginId = Console.ReadLine();
                            Console.WriteLine("Password:");
                            string password = Console.ReadLine();
                            Console.WriteLine("CustomerId:");
                            string customerId = Console.ReadLine();
                            Console.WriteLine("EmployeeId:");
                            string employeeId = Console.ReadLine();
                            Console.WriteLine("AccessLevel:");
                            string accessLevel = Console.ReadLine();
                            Console.WriteLine();
                            List<MyNamespace.MyKeyValuePairCustom> loginData = new List<MyNamespace.MyKeyValuePairCustom>
                            {
                                new MyNamespace.MyKeyValuePairCustom("LoginId", loginId),
                            new MyNamespace.MyKeyValuePairCustom("Password", password),
                            new MyNamespace.MyKeyValuePairCustom("CustomerId", customerId),
                            new MyNamespace.MyKeyValuePairCustom("EmployeeId", employeeId),
                            new MyNamespace.MyKeyValuePairCustom("AccessLevel", accessLevel)
                        };

                            if (proxy.Create(loginData.Select(x => (KeyValuePairCustom)x).ToArray(), selectedEntityCon, role))
                            {
                                Console.WriteLine("Login created successfully!");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Creation failed. Try again. (invalid values or no admin rights).");
				Console.WriteLine(proxy.GetErrorMessage());
                            }

                        }

                    }
                    else if (nextAction.ToLower() == "delete")
                    {
                        Console.WriteLine("Enter the ID of the entity you want to delete:");
                        string idDelete = Console.ReadLine();
                        Console.WriteLine();
                        if (proxy.Delete(idDelete, selectedEntityCon, role))
                        {
                            Console.WriteLine("delete successfull!");
                            continue;
                        }

                        else
                        {
                            Console.WriteLine("delete failed. Try again.)");
			    Console.WriteLine(proxy.GetErrorMessage());
                        }


                    }
                    else if (nextAction.ToLower() == "view table")
                    {
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the table you want to view of the following options:");
                            Console.WriteLine("Employee, Customer, Computer, Game, Login");
                            Console.WriteLine();
                            selectedEntityCon = Console.ReadLine();
                            Console.WriteLine();
                            if (selectedEntityCon == "Employee" || selectedEntityCon == "Customer" || selectedEntityCon == "Computer" || selectedEntityCon == "Game" || selectedEntityCon == "Login")
                            {
                                result = proxy.GetSelectedEntityData(selectedEntityCon, role);
                                if (!string.IsNullOrEmpty(result))
                                {
                                    Console.WriteLine(result);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("View failed. Please try again.");
                                    Console.WriteLine();
				    Console.WriteLine(proxy.GetErrorMessage());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection. Please enter a valid table name and try again.");
                                Console.WriteLine();
                            }
                        }
                        continue;
                    }


                    else if (nextAction.ToLower() == "logout")
                    {
                        success = true;
			Console.Clear();
                    }

                }

            }

            else
            {
                Console.WriteLine("Password or username is incorrect.");
                Console.WriteLine();
                Console.WriteLine("Do you want to try again or quit?");
                String quitter = Console.ReadLine();

                if (quitter == "quit")
                {
                    quit = true;
		    Console.Clear();	
                }
            }

        }
    }
}