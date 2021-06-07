using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace Exo_Recap_1_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DB_Exo_Recap_1; Integrated Security = True;");

            CategoriesService _categoriesService = new CategoriesService(connection);

            #region Afficher les catégories

            IEnumerable<Category> catList = _categoriesService.Get();
            //foreach (Category item in catList)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("");
            #endregion

            #region Ajouter une catégorie "Autre"

            //Category Autre = new Category
            //{
            //    Name = "Autre"
            //};

            //_categoriesService.Insert(Autre);
            #endregion

            #region Recuperer le nom de la catégorie dont l'id est 2

            Category cat2 = _categoriesService.Get(2);
            //Console.WriteLine($"{cat2.Name}\n");

            #endregion

            #region Creer deux contacts pour chaque categorie, afficher la liste des contacts

            Contact wick = new Contact
            {
                FirstName = "John",
                LastName = "Wick",
                Email = "john.wick@gmail.com",
                IdCategory = 2
            };

            Contact paine = new Contact
            {
                FirstName = "Max",
                LastName = "Paine",
                Email = "max.payne@gmail.com",
                IdCategory = 2
            };

            Contact aveni = new Contact
            {
                FirstName = "Nino",
                LastName = "Aveni",
                Email = "aveni.nino@gmail.com",
                IdCategory = 1
            };

            Contact baudo = new Contact
            {
                FirstName = "Guido",
                LastName = "Baudo",
                Email = "guido.baudo@gmail.com",
                IdCategory = 1
            };

            ContactsService _contactsService = new ContactsService(connection);
            //_contactsService.Insert(wick);
            //_contactsService.Insert(paine);
            //_contactsService.Insert(aveni);
            //_contactsService.Insert(baudo);

            //IEnumerable<Contact> conList = _contactsService.Get();
            //foreach (Contact item in conList)
            //{
            //    Console.WriteLine($"First name: {item.FirstName}\nLast name: {item.LastName}\nEmail: {item.Email}\nCategory ID: {item.IdCategory}\n");
            //}
            //Console.WriteLine("");


            #endregion

            #region Afficher la liste des contacts pour chaque categorie

            IEnumerable<Contact> getListById1 = _contactsService.GetByCategory(1);
            IEnumerable<Contact> getListById2 = _contactsService.GetByCategory(2);

            //foreach (Contact item in getListById1)
            //{
            //    Console.WriteLine(item.LastName);
            //}

            //foreach (Contact item in getListById2)
            //{
            //    Console.WriteLine(item.LastName);
            //}
            #endregion

            #region Mettre à jour un contact de la categorie Personnel

            Contact allachie = new Contact
            {
                FirstName = "Glen",
                LastName = "Allachie",
                Email = "glen.allachie@gmail.com",
                IdCategory = 2
            };
            //_contactsService.Update(1, allachie);

            IEnumerable<Contact> conList = _contactsService.Get();
            //foreach (Contact item in conList)
            //{
            //    Console.WriteLine($"First name: {item.FirstName}\nLast name: {item.LastName}\nEmail: {item.Email}\nCategory ID: {item.IdCategory}\n");
            //}
            //Console.WriteLine("");
            #endregion

            #region Supprimer un contact de la catégorie Autre

            //_contactsService.Delete(5);
            //_contactsService.Delete(6);
            //_contactsService.Delete(7);
            //_contactsService.Delete(8);
            //_contactsService.Delete(9);
            //_contactsService.Delete(10);
            //_contactsService.Delete(11);
            //_contactsService.Delete(12);
            //_contactsService.Delete(13);
            //_contactsService.Delete(14);
            //_contactsService.Delete(15);
            //_contactsService.Delete(16);
            //_contactsService.Delete(17);
            //_contactsService.Delete(18);
            //_contactsService.Delete(19);
            //_contactsService.Delete(20);
            //_contactsService.Delete(21);
            //_contactsService.Delete(22);
            //_contactsService.Delete(23);
            //_contactsService.Delete(24);

            foreach (Contact item in conList)
            {
                Console.WriteLine($"First name: {item.FirstName}\nLast name: {item.LastName}\nEmail: {item.Email}\nCategory ID: {item.IdCategory}\n");
            }
            Console.WriteLine("");

            #endregion


        }
    }
}
