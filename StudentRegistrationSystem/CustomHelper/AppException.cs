using Microsoft.Build.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StudentRegistrationSystem.CustomHelper
{
    public class AppException:Exception
    {
        public AppException(string message, Exception exception) : base(message, exception)
        {
 //Logger.SendErrorToText(exception);
        }
    }
}



namespace EmployeeManagement.CustomHelper
{
    public class AppException : Exception
    {
        public AppException(string message, Exception exception) : base(message, exception)
        {
           // Logger.SendErrorToText(exception);
        }
    }
}