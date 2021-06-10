using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;
using GContactService = Exo_Recap_1_Console.ContactsService;
using Exo_Recap_1_Console.Client.Mappers;
using C = Exo_Recap_1_Console.Client.Data;

namespace Exo_Recap_1_Console.Client.Services
{
    class ContactsService
    {
        private readonly GContactService _contactService;

        public ContactsService(GContactService contactService)
        {
            _contactService = contactService;
        }
        public IEnumerable<Contact> Get()
        {
            return _contactService.Get();
        }
        public IEnumerable<Contact> GetByCategory(int id)
        {
            return _contactService.GetByCategory(id);
        }
        public Contact Get(int id)
        {
            return _contactService.Get(id);
        }
        public bool Insert(Contact contact)
        {
            return _contactService.Insert(contact);
        }
        public bool Update(int id, Contact contact)
        {
            return _contactService.Update(id, contact);
        }
        public bool Delete(int id)
        {
            return _contactService.Delete(id);
        }


    }
}
