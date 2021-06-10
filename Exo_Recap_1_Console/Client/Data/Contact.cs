using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Recap_1_Console.Client.Data
{
    class Contact
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int IdCategory { get; set; }
        public Contact(string lastname, string firstname, string email, int idCategory)
        {
            LastName = lastname;
            FirstName = firstname;
            Email = email;
            IdCategory = idCategory;
        }

        internal Contact(int id, string lastname, string firstname, string email, int idCategory) : this(lastname, firstname, email, idCategory)
        {
            Id = id;
        }
    }
}
