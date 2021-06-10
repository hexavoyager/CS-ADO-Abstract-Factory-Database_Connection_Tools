using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;
using G = Exo_Recap_1_Console.Global.Services;
using Exo_Recap_1_Console.Client.Mappers;
using C = Exo_Recap_1_Console.Client.Data;
using Exo_Recap_1_Console.Client.Data;

namespace Exo_Recap_1_Console.Client.Services
{
    class ContactsService
    {
        private readonly G.ContactsService _contactService;

        public ContactsService(G.ContactsService contactService)
        {
            _contactService = contactService;
        }
        public IEnumerable<Contact> Get()
        {
            return _contactService.Get().Select(c => c.ToClient());
        }
        public IEnumerable<Contact> GetByCategory(int id)
        {
            return _contactService.GetByCategory(id).Select(c => c.ToClient());
        }
        public Contact Get(int id)
        {
            return _contactService.Get(id)?.ToClient();
        }
        public bool Insert(Contact contact)
        {
            return _contactService.Insert(contact.ToGlobal());
        }
        public bool Update(int id, Contact contact)
        {
            return _contactService.Update(id, contact.ToGlobal());
        }
        public bool Delete(int id)
        {
            return _contactService.Delete(id);
        }


    }
}
