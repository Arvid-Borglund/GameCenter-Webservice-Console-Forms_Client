using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsClient.ConnectionErrorHandler;


namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RunGameCenter();
        }

        WebServiceGameCenter proxy = new WebServiceGameCenter();
        ConnectionErrorHandler errorHandler = new ConnectionErrorHandler();

        private async Task<string> WaitForInput()
        {
            var tcs = new TaskCompletionSource<string>();

            EventHandler onClick = null;
            onClick = (s, e) =>
            {
                string input = txtBoxInput.Text.Trim();
                txtBoxInput.Clear();
                txtBoxInput.Focus();
                tcs.SetResult(input);
                btnSubmit.Click -= onClick;
            };

            btnSubmit.Click += onClick;

            return await tcs.Task;
        }


        private void TxtBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }
      //       this.txtBoxInput.KeyDown += TxtBoxInput_KeyDown; 

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

        }


        private void DisplayOutput(string output)
        {
            txtBoxData.AppendText(output);
            txtBoxData.SelectionStart = txtBoxData.Text.Length;
            txtBoxData.ScrollToCaret();
        }


        private async Task RunGameCenter()
        {
            // Created delegates to (Web)methods that will be called, so they can be passed
            // to the TestCallConnection method that can handle any exceptions that might occur when  
            // calling that delegate.
            GetSelectedEntityDataDelegate getSelectedEntityDataDelegate = (entityCon, r) => proxy.GetSelectedEntityData(entityCon, r);
            DeleteDelegate deleteDelegate = (idd, entityCon, r) => proxy.Delete(idd, entityCon, r);
            CreateDelegate createDelegate = (data, entity, r) => proxy.Create(data.Select(x => (KeyValuePairCustom)x).ToArray(), entity, r);
            VerifyCredentialsDelegate verifyCredentialsDelegate = (string id, string loginPassword, out string role) => proxy.VerifyCredentials(id, loginPassword, out role);

            bool quit = false;

            while (!quit)
            {
                DisplayOutput( Environment.NewLine);
                DisplayOutput( Environment.NewLine);
                DisplayOutput( Environment.NewLine);
                DisplayOutput( Environment.NewLine);
                DisplayOutput( "                                                     * * *      ******* " + Environment.NewLine);
                DisplayOutput( "                                                   * ^^    * ********          *****" + Environment.NewLine);
                DisplayOutput( "                                                  *O           *********  ******" + Environment.NewLine);
                DisplayOutput( " !!Welcome to Game Center!!    >---                    ** " + Environment.NewLine);
                DisplayOutput( "                                                   * * * ***     *******   *******" + Environment.NewLine);
                DisplayOutput( "                                                           ** * *         ******" + Environment.NewLine);
                DisplayOutput( Environment.NewLine);
                DisplayOutput( Environment.NewLine);
                DisplayOutput( "Enter your login ID:" + Environment.NewLine);

                string id = await WaitForInput();
                DisplayOutput( "Enter your password:" + Environment.NewLine);
                string loginPassword = await WaitForInput();
                DisplayOutput( Environment.NewLine);
                string role = "";

                // Verify the credentials
                try
                {
                    // Call the delegate and check the result
                    bool verifyResult = errorHandler.TestCallConnection(() => verifyCredentialsDelegate(id, loginPassword, out role), "Invalid credentials.");
                    //String testErrorHandling = proxy.TryErrorHandling();

                    if (verifyResult == true && role != "Admin" && role != "Employee")
                    {
                        txtBoxData.Text = "Only employees may use this application!" + Environment.NewLine;
                        DisplayOutput( Environment.NewLine);
                        DisplayOutput( Environment.NewLine);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    txtBoxData.Clear();
                    DisplayOutput( "Unable to proceed due to: " + ex.Message + Environment.NewLine);
                    DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                    DisplayOutput( "Do you want to try again or quit?" + Environment.NewLine);
                    String quitter = await WaitForInput();

                    if (quitter == "quit")
                    {
                        quit = true;
                        txtBoxData.Clear();
                        this.Close();
                    }
                    else
                    {
                        continue;
                    }
                }
                if (role == "Admin" || role == "Employee")
                {
                    DisplayOutput( "Password and username is correct, these are your table options:" + Environment.NewLine);
                    DisplayOutput( "Employee, Customer, Computer, Game, Login" + Environment.NewLine);
                    DisplayOutput( Environment.NewLine);
                    string selectedEntityCon = "";
                    bool validSelection = false;
                    while (!validSelection)
                    {
                        DisplayOutput( "Enter the table you want to access:" + Environment.NewLine);

                        selectedEntityCon = await WaitForInput();

                        DisplayOutput( Environment.NewLine);

                        if (selectedEntityCon == "Employee" || selectedEntityCon == "Customer" || selectedEntityCon == "Computer" || selectedEntityCon == "Game" || selectedEntityCon == "Login")
                        {
                            validSelection = true;
                            txtBoxData.Clear();
                        }
                        else
                        {
                            DisplayOutput( "There is no such table. Try again." + Environment.NewLine);
                        }
                    }
                    try
                    {
                        string resultView = errorHandler.TestCallConnection(() => getSelectedEntityDataDelegate(selectedEntityCon, role), "View failed. Please try again.");
                        if (!string.IsNullOrEmpty(resultView))
                        {                           
                            DisplayOutput(resultView);
                            DisplayOutput(Environment.NewLine);                           
                        }
                    }
                    catch (Exception ex)
                    {
                        DisplayOutput( "An error occurred while retrieving the data: " + ex.Message + Environment.NewLine);
                        DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                    }
                    DisplayOutput( Environment.NewLine);

                    bool success = false;

                    while (!success)
                    {
                        DisplayOutput( Environment.NewLine);
                        DisplayOutput( "What would you like to do next?" + Environment.NewLine);
                        DisplayOutput( Environment.NewLine);
                        DisplayOutput( "Create, Delete, View table, logout" + Environment.NewLine);
                        string nextAction = await WaitForInput();

                        if (nextAction.ToLower() == "create")
                        {
                            List<MyKeyValuePairCustom> entityData = new List<MyKeyValuePairCustom>();
                            DisplayOutput( Environment.NewLine);

                            if (selectedEntityCon == "Computer")
                            {
                                DisplayOutput( "Enter the values for the new computer:" + Environment.NewLine);
                                DisplayOutput( Environment.NewLine);
                                DisplayOutput( "ComputerId:" + Environment.NewLine);
                                string computerId = await WaitForInput();
                                DisplayOutput( "Cpu:" + Environment.NewLine);
                                string cpu = await WaitForInput();
                                DisplayOutput( "Gpu:" + Environment.NewLine);
                                string gpu = await WaitForInput();
                                DisplayOutput( "Ram:" + Environment.NewLine);
                                string ram = await WaitForInput();
                                DisplayOutput( "DataStorage:" + Environment.NewLine);
                                string dataStorage = await WaitForInput();
                                DisplayOutput( Environment.NewLine);
                                List<MyKeyValuePairCustom> computerData = new List<MyKeyValuePairCustom>
                                {
                                    new MyKeyValuePairCustom("ComputerId", computerId),
                                    new MyKeyValuePairCustom("Cpu", cpu),
                                    new MyKeyValuePairCustom("Gpu", gpu),
                                    new MyKeyValuePairCustom("Ram", ram),
                                    new MyKeyValuePairCustom("DataStorage", dataStorage)
                                };
                                try
                                {
                                    errorHandler.TestCallConnection(() => createDelegate(computerData.Select(x => (KeyValuePairCustom)x).ToList(), selectedEntityCon, role), "One or more of the values you entered is invalid. Please try again.");
                                    DisplayOutput( "Computer successfully created." + Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    DisplayOutput( "An error occurred while creating the computer: " + ex.Message + Environment.NewLine);
                                    DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                                }
                            }
                            else if (selectedEntityCon == "Employee")
                            {
                                DisplayOutput( "Enter the values for the new employee:" + Environment.NewLine);
                                DisplayOutput( Environment.NewLine);
                                DisplayOutput( "EmployeeId:" + Environment.NewLine);
                                string employeeId = await WaitForInput();
                                DisplayOutput( "Name:" + Environment.NewLine);
                                string name = await WaitForInput();
                                DisplayOutput( "Address:" + Environment.NewLine);
                                string address = await WaitForInput();
                                DisplayOutput( "PhoneNumber:" + Environment.NewLine);
                                string phoneNumber = await WaitForInput();
                                DisplayOutput( "Email:" + Environment.NewLine);
                                string email = await WaitForInput();
                                DisplayOutput( "JobTitle:" + Environment.NewLine);
                                string jobTitle = await WaitForInput();
                                DisplayOutput( Environment.NewLine);
                                List<MyKeyValuePairCustom> employeeData = new List<MyKeyValuePairCustom>
                                {
                                    new MyKeyValuePairCustom("EmployeeId", employeeId),
                                    new MyKeyValuePairCustom("Name", name),
                                    new MyKeyValuePairCustom("Address", address),
                                    new MyKeyValuePairCustom("PhoneNumber", phoneNumber),
                                    new MyKeyValuePairCustom("Email", email),
                                    new MyKeyValuePairCustom("JobTitle", jobTitle)
                                };
                                try
                                {
                                    errorHandler.TestCallConnection(() => createDelegate(employeeData.Select(x => (KeyValuePairCustom)x).ToList(), selectedEntityCon, role), "One or more of the values you entered is invalid. Please try again.");
                                    DisplayOutput( "Employee created successfully!" + Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    DisplayOutput( "An error occurred while creating the employee: " + ex.Message + Environment.NewLine);
                                    DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                                }
                            }
                            else if (selectedEntityCon == "Customer")
                            {
                                DisplayOutput( "Enter the values for the new customer:" + Environment.NewLine);
                                DisplayOutput( Environment.NewLine);
                                DisplayOutput( "CustomerId:" + Environment.NewLine);
                                string customerId = await WaitForInput();
                                DisplayOutput( "Name:" + Environment.NewLine);
                                string name = await WaitForInput();
                                DisplayOutput( "Address:" + Environment.NewLine);
                                string address = await WaitForInput();
                                DisplayOutput( "PhoneNumber:" + Environment.NewLine);
                                string phoneNumber = await WaitForInput();
                                DisplayOutput( "Email:" + Environment.NewLine);
                                string email = await WaitForInput();
                                DisplayOutput( "LoyaltyLevel:" + Environment.NewLine);
                                string loyaltyLevel = await WaitForInput();
                                DisplayOutput( Environment.NewLine);
                                List<MyKeyValuePairCustom> customerData = new List<MyKeyValuePairCustom>
                                {
                                    new MyKeyValuePairCustom("CustomerId", customerId),
                                    new MyKeyValuePairCustom("Name", name),
                                    new MyKeyValuePairCustom("Address", address),
                                    new MyKeyValuePairCustom("PhoneNumber", phoneNumber),
                                    new MyKeyValuePairCustom("Email", email),
                                    new MyKeyValuePairCustom("LoyaltyLevel", loyaltyLevel)
                                };
                                try
                                {
                                    errorHandler.TestCallConnection(() => createDelegate(customerData.Select(x => (KeyValuePairCustom)x).ToList(), selectedEntityCon, role), "One or more of the values you entered is invalid. Please try again.");
                                    DisplayOutput( "Customer created successfully!" + Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    DisplayOutput( "An error occurred while creating the customer: " + ex.Message + Environment.NewLine);
                                    DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                                }
                            }
                            else if (selectedEntityCon == "Game")
                            {
                                DisplayOutput( "Enter the values for the new game:" + Environment.NewLine);
                                DisplayOutput( Environment.NewLine);
                                DisplayOutput( "GameId:" + Environment.NewLine);
                                string gameId = await WaitForInput();
                                DisplayOutput( "ComputerId:" + Environment.NewLine);
                                string computerId = await WaitForInput();
                                DisplayOutput( "Title:" + Environment.NewLine);
                                string title = await WaitForInput();
                                DisplayOutput("Genre:" + Environment.NewLine);
                                string genre = await WaitForInput();
                                DisplayOutput( Environment.NewLine);
                                List<MyKeyValuePairCustom> gameData = new List<MyKeyValuePairCustom>
                                {
                                        new MyKeyValuePairCustom("GameId", gameId),
                                        new MyKeyValuePairCustom("ComputerId", computerId),
                                        new MyKeyValuePairCustom("Title", title),
                                        new MyKeyValuePairCustom("Genre", genre)
                                };

                                try
                                {
                                    errorHandler.TestCallConnection(() => createDelegate(gameData.Select(x => (KeyValuePairCustom)x).ToList(), selectedEntityCon, role), "One or more of the values you entered is invalid. Please try again.");
                                    DisplayOutput("Game created successfully!" + Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    DisplayOutput( "An error occurred while creating the game: " + ex.Message + Environment.NewLine);
                                    DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                                }
                            }
                            else if (selectedEntityCon == "Login")
                            {
                                DisplayOutput( "Enter the values for the new login:" + Environment.NewLine);
                                DisplayOutput( Environment.NewLine);
                                DisplayOutput( "LoginId:" + Environment.NewLine);
                                string loginId = await WaitForInput();
                                DisplayOutput( "Password:" + Environment.NewLine);
                                string password = await WaitForInput();
                                DisplayOutput( "CustomerId:" + Environment.NewLine);
                                string customerId = await WaitForInput();
                                DisplayOutput( "EmployeeId:" + Environment.NewLine);
                                string employeeId = await WaitForInput();
                                DisplayOutput( "AccessLevel:" + Environment.NewLine);
                                string accessLevel = await WaitForInput();
                                DisplayOutput( Environment.NewLine);
                                List<MyKeyValuePairCustom> loginData = new List<MyKeyValuePairCustom>
                                {
                                        new MyKeyValuePairCustom("LoginId", loginId),
                                        new MyKeyValuePairCustom("Password", password),
                                        new MyKeyValuePairCustom("CustomerId", customerId),
                                        new MyKeyValuePairCustom("EmployeeId", employeeId),
                                        new MyKeyValuePairCustom("AccessLevel", accessLevel)
                                };
                                try
                                {
                                    errorHandler.TestCallConnection(() => createDelegate(loginData.Select(x => (KeyValuePairCustom)x).ToList(), selectedEntityCon, role), "One or more of the values you entered is invalid. Please try again.");
                                    DisplayOutput( "Login created successfully!" + Environment.NewLine);
                                }
                                catch (Exception ex)
                                {
                                    DisplayOutput( "An error occurred while creating the login: " + ex.Message + Environment.NewLine);
                                    DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                                }
                            }
                        }
                        else if (nextAction.ToLower() == "delete")
                        {
                            DisplayOutput( "Enter the ID of the entity you want to delete:" + Environment.NewLine);
                            string idDelete = await WaitForInput();
                            DisplayOutput( Environment.NewLine);
                            // Call the TestCallConnection method with the deleteDelegate and appropriate error message
                            try
                            {
                                errorHandler.TestCallConnection(() => deleteDelegate(idDelete, selectedEntityCon, role), "Failed to delete entity.");
                                DisplayOutput( "Entity successfully deleted." + Environment.NewLine);
                            }
                            catch (Exception ex)
                            {
                                DisplayOutput( "An error occurred while deleting the entity: " + ex.Message + Environment.NewLine);
                                DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                            }
                            continue;
                        }

                        else if (nextAction.ToLower() == "view table")
                        {
                            while (true)
                            {
                                txtBoxData.Clear();
                                DisplayOutput( Environment.NewLine);
                                DisplayOutput( "Enter the table you want to view of the following options:" + Environment.NewLine);
                                DisplayOutput( "Employee, Customer, Computer, Game, Login" + Environment.NewLine);
                                DisplayOutput( Environment.NewLine);

                                selectedEntityCon = await WaitForInput();

                                txtBoxData.Clear();
                                if (selectedEntityCon == "Employee" || selectedEntityCon == "Customer" || selectedEntityCon == "Computer" || selectedEntityCon == "Game" || selectedEntityCon == "Login")
                                {
                                    try
                                    {
                                        string resultView = errorHandler.TestCallConnection(() => getSelectedEntityDataDelegate(selectedEntityCon, role), "View failed. Please try again.");
                                        if (!string.IsNullOrEmpty(resultView))
                                        {
                                            DisplayOutput( resultView);
                                            DisplayOutput(Environment.NewLine);
                                            break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        DisplayOutput( "An error occurred while retrieving the data: " + ex.Message + Environment.NewLine);
                                        DisplayOutput( await errorHandler.GetSQLErrorMessageWithTimeout() + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    DisplayOutput( "Invalid selection. Please enter a valid table name and try again." + Environment.NewLine);
                                    DisplayOutput( Environment.NewLine);
                                }
                            }
                            continue;
                        }
                        else if (nextAction.ToLower() == "logout")
                        {
                            success = true;
                            txtBoxData.Clear();
                        }
                    }
                }
            }
        }
    }
}


