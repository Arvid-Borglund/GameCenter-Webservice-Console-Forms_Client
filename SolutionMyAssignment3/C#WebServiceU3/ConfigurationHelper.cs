using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Web.Hosting;


namespace WebApplicationGameCenter
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(HostingEnvironment.MapPath("~"))
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }

}