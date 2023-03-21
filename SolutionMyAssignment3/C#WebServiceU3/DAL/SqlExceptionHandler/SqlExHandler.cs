using System;

namespace WebApplicationGameCenter.DAL.SqlExceptionHandler
{
    public class SqlExHandler
    {
        // create methods for handling sql connection exceptions
        public static string HandleSqlException(Exception ex, string customErrorMessage = null)
        {
            // Find the innermost exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            // if the exception is a sql exception
            if (ex is System.Data.SqlClient.SqlException)
            {
                // Check the number
                switch (((System.Data.SqlClient.SqlException)ex).Number)
                {
                    // Cannot open database requested by the login. The login failed.
                    case 4060:
                        return customErrorMessage ?? "Cannot open database requested by the login. The login failed.";
                    // Cannot open database "%.*ls" requested by the login. The login failed.
                    case 18456:
                        return customErrorMessage ?? "Cannot open database requested by the login. The login failed.";
                    // A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - The specified network name is no longer available.)
                    case 53:
                        return customErrorMessage ?? "A network-related or instance-specific error occurred while establishing a connection to SQL Server.";
                    // A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - An existing connection was forcibly closed by the remote host.)
                    case 10054:
                        return customErrorMessage ?? "A network-related or instance-specific error occurred while establishing a connection to SQL Server.";
                    default:
                        return customErrorMessage ?? ex.Message;
                }
            }
            else
            {
                return customErrorMessage ?? ex.Message;
            }
        }


    }
}    
