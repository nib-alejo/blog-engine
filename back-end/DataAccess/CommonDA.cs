using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommonDA
    {
        public CommonDA()
        {
            ConnectionString = @"Data Source = tcp:lockheed.database.windows.net,1433; Initial Catalog = BlogEngine; user id = zemoga; password = Z3m0g4321;";
        }

        public string ConnectionString { get; set; }
    }
}
