using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo_Recap_1_Console.Client.Data;
using G = Exo_Recap_1_Console.Global.Data;

namespace Exo_Recap_1_Console.Client.Mappers
{
    static class Mappers
    {
        internal static Contact ToClient(this G.Contact contact)
        {
            return new Contact(contact.Id, contact.LastName, contact.FirstName, contact.Email, contact.IdCategory);
        }
        internal static G.Contact ToGlobal(this Contact contact)
        {
            return new G.Contact()
            {
                Id = contact.Id,
                LastName = contact.LastName,
                FirstName = contact.FirstName,
                Email = contact.Email,
                IdCategory = contact.IdCategory
            };
        }
        internal static Category ToClient(this G.Category category)
        {
            return new Category(category.Id, category.Name);
        }
        internal static G.Category ToGlobal(this Category category)
        {
            return new G.Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
