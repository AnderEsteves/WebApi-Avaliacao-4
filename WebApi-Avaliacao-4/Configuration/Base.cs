using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Avaliacao_4.Configuration
{
    public class Base
    {
        public static string GetConnectionString()
        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["loja"].ConnectionString;

        }
    }
}