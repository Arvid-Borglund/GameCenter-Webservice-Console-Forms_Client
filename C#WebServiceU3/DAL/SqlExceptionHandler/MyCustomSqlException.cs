using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationGameCenter.DAL.SqlExceptionHandler
{
    [Serializable]
    public class MyCustomSqlException : Exception
    {
        public MyCustomSqlException(int errorNumber) : base(GetErrorMessage(errorNumber))
        {
        }
        private static string GetErrorMessage(int errorNumber)
        {
            switch (errorNumber)
            {
                case 4060:
                    return "Cannot open database requested by the login. The login failed.";
                case 18456:
                    return "Cannot open database requested by the login. The login failed.";
                case 53:
                    return "A network-related or instance-specific error occurred while establishing a connection to SQL Server.";
                case 10054:
                    return "A network-related or instance-specific error occurred while establishing a connection to SQL Server.";
                default:
                    return "An error occurred in the database.";
            }
        }
    }
}