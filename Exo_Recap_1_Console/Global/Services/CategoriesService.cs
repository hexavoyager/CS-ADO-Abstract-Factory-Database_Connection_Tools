using Exo_Recap_1_Console.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;
using Exo_Recap_1_Console.Global.Mappers;

namespace Exo_Recap_1_Console.Global.Services
{
    public class CategoriesService
    {
       private readonly Connection _connection;
        public CategoriesService(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Category> Get() {

            Command command = new Command("select * from [Category]", false);
            return _connection.ExecuteReader(command, dr => dr.ToCategory()); 
        }
        public Category Get(int id)
        {
            Command command = new Command("select * from [Category] where id=@id", false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.ToCategory()).SingleOrDefault();
        }
        public bool Insert(Category category)
        {
            Command command = new Command("insert into [Category] (Name) values (@Name)", false);
            command.AddParameter("Name", category.Name);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
