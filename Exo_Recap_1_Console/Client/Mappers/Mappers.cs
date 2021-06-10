using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = Exo_Recap_1_Console.Client.Data;

namespace Exo_Recap_1_Console.Client.Mappers
{
    static class Mappers
    {
        internal static C.Contact ToClient(this Contact contact)
        {
            return new C.Contact(contact.Id, contact.LastName, contact.FirstName, contact.Email, contact.IdCategory);
        }
        internal static Contact ToGlobal(this C.Contact contact)
        {
            return new Contact()
            {
                Id = contact.Id,
                LastName = contact.LastName,
                FirstName = contact.FirstName,
                Email = contact.Email,
                IdCategory = contact.IdCategory
            };
        }
        internal static C.Category ToClient(this Category category)
        {
            return new C.Category(category.Id, category.Name);
        }
        internal static Category ToGlobal(C.Category category)
        {
            return new Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
