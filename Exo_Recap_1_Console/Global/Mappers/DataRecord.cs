using Exo_Recap_1_Console.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Recap_1_Console.Global.Mappers
{

    public static class DataRecord 
    {
        public static Category ToCategory(this IDataRecord record)
        {
            return new Category
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"]
            };
        }

        public static Contact ToContact(this IDataRecord record)
        {
            return new Contact
            {
                Id = (int)record["Id"],
                LastName = (string)record["LastName"],
                FirstName = (string)record["FirstName"],
                Email = (string)record["Email"],
                IdCategory = (int)record["IdCategory"]
            };
        }
    }
}
