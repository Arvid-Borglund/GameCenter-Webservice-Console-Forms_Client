using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Services.Protocols;


namespace WindowsFormsClient
{
    internal class ConnectionErrorHandler
    {
        WebServiceGameCenter proxy = new WebServiceGameCenter();
        internal delegate bool VerifyCredentialsDelegate(string id, string loginPassword, out string role);
        //internal delegate string VerifyCredentialsJavaDelegate(string id, string loginPassword);
        internal delegate string GetSelectedEntityDataDelegate(string selectedEntityCon, string role);
        internal delegate bool CreateDelegate(List<KeyValuePairCustom> entityData, string selectedEntityCon, string role);
        internal delegate bool DeleteDelegate(string idDelete, string selectedEntityCon, string role);

        internal T TestCallConnection<T>(Func<T> method, string errorMessage)
        {
            try
            {
                // Call the method and check the result
                T result = method();

                if (result != null && (typeof(T) != typeof(bool) || (bool)(object)result))
                {
                    return result;
                }
                else
                {
                    throw new Exception("Login failed.");
                }

            }
            catch (WebException ex)
            {
                throw new Exception("Error connecting to webservice.", ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("The webservice did not respond within the allotted time.", ex);
            }
            catch (SoapException ex)
            {
                Console.WriteLine($"Error Message: {ex.Message}");

                // Log the SOAP fault code and actor
                Console.WriteLine($"SOAP Fault Code: {ex.Code}");
                Console.WriteLine($"SOAP Fault Actor: {ex.Actor}");

                // Log the SOAP fault details
                Console.WriteLine($"SOAP Fault Details: {ex.Detail}");


                throw new Exception("The webservice returned a SOAP fault message.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(errorMessage, ex);
            }
        }

        internal async Task<string> GetSQLErrorMessageWithTimeout()
        {
            string errorMessage = null;

            try
            {
                if (proxy != null) // check if the proxy object is not null
                {
                    // Call the GetErrorMessage method with a timeout of 2 seconds
                    Task<string> errorMessageTask = Task.Run(() => proxy.GetErrorMessage());
                    await Task.WhenAny(errorMessageTask, Task.Delay(2000));
                    if (errorMessageTask.IsCompleted)
                    {
                        errorMessage = errorMessageTask.Result;
                    }
                    else
                    {
                        // The task timed out
                        errorMessage = "Error: GetErrorMessage timed out!";
                    }
                }
                else
                {
                    errorMessage = "Error: Web service proxy object is null!";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                errorMessage = ex.Message;
            }

            return errorMessage;
        }





    }
}
