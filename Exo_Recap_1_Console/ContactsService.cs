using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace Exo_Recap_1_Console
{
    public class ContactsService
    {
        private readonly Connection _connection;
        public ContactsService(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Contact> Get()
        {
            Command command = new Command("select * from [Contact]", false);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }
        public IEnumerable<Contact>GetByCategory(int id)
        {
            Command command = new Command("select * from [Contact] where IdCategory=@id", false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }
        public Contact Get(int id)
        {
            Command command = new Command("select * from [Contact] where id=@id", false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }
        public bool Insert(Contact contact)
        {
            Command command = new Command("insert into [Contact] (LastName, FirstName, Email, IdCategory) values (@LastName, @FirstName, @Email, @IdCategory)", false);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("IdCategory", contact.IdCategory);
            return _connection.ExecuteNonQuery(command) == 1;
        }
        public bool Update(int id, Contact contact)
        {
            Command command = new Command("update [Contact] set LastName = @LastName, FirstName = @FirstName, Email = @Email, IdCategory = @IdCategory where id=@id", false);
            command.AddParameter("id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("IdCategory", contact.IdCategory);
            return _connection.ExecuteNonQuery(command) == 1;
        }
        public bool Delete(int id)
        {
            Command command = new Command("delete from [Contact] where id=@id", false);
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
