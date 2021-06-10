using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;
using G = Exo_Recap_1_Console.Global.Services;
using Exo_Recap_1_Console.Client.Services;
using Exo_Recap_1_Console.Client.Data;
 

namespace Exo_Recap_1_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DB_Exo_Recap_1; Integrated Security = True;");

            G.CategoriesService _categoriesService = new G.CategoriesService(connection);

            CategoriesService categoriesService = new CategoriesService(_categoriesService);

            G.ContactsService _contactsService = new G.ContactsService(connection);

            ContactsService contactsService = new ContactsService(_contactsService);

            #region Afficher les catégories

            Console.WriteLine("EXO1");
            IEnumerable<Category> catList = categoriesService.Get();
            foreach (Category item in catList)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("");
            #endregion

            #region Ajouter une catégorie "Autre"
            Console.WriteLine("EXO2");
            Category Autre = new Category("Autre");

            categoriesService.Insert(Autre);
            #endregion

            #region Recuperer le nom de la catégorie dont l'id est 2

            Category cat2 = categoriesService.Get(2);
            //Console.WriteLine($"{cat2.Name}\n");

            #endregion

            #region Creer deux contacts pour chaque categorie, afficher la liste des contacts

            Contact wick = new Contact("Wick", "John", "john.wick@gmail.com", 2);

            Contact paine = new Contact("Paine", "Max", "max.payne@gmail.com", 2);

            Contact aveni = new Contact("Aveni", "Nino", "aveni.nino@gmail.com", 1);

            Contact baudo = new Contact("Baudo", "Guido", "guido.baudo@gmail.com", 1);


            //contactsService.Insert(wick);
            //contactsService.Insert(paine);
            //contactsService.Insert(aveni);
            //contactsService.Insert(baudo);

            IEnumerable<Contact> conList = contactsService.Get();

            foreach (Contact item in conList)
            {
                Console.WriteLine($"First name: {item.FirstName}\nLast name: {item.LastName}\nEmail: {item.Email}\nCategory ID: {item.IdCategory}\n");
            }

            Console.WriteLine();
            #endregion

            #region Afficher la liste des contacts pour chaque categorie

            IEnumerable<Contact> getListById1 = contactsService.GetByCategory(1);
            IEnumerable<Contact> getListById2 = contactsService.GetByCategory(2);

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

            Contact allachie = new Contact("Allachie", "Glen", "glen.allachie@gmail.com", 2);

            contactsService.Update(1, allachie);

            IEnumerable<Contact> connList = contactsService.Get();
            foreach (Contact item in connList)
            {
                Console.WriteLine($"First name: {item.FirstName}\nLast name: {item.LastName}\nEmail: {item.Email}\nCategory ID: {item.IdCategory}\n");
            }
            Console.WriteLine();
            #endregion

            #region Supprimer un contact de la catégorie Autre

            //contactsService.Delete(5);
            //contactsService.Delete(5);
            //contactsService.Delete(6);
            //contactsService.Delete(7);
            //contactsService.Delete(8);
            //contactsService.Delete(9);
            //contactsService.Delete(10);
            //contactsService.Delete(11);
            //contactsService.Delete(12);
            //contactsService.Delete(13);
            //contactsService.Delete(14);
            //contactsService.Delete(15);
            //contactsService.Delete(16);
            //contactsService.Delete(17);
            //contactsService.Delete(18);
            //contactsService.Delete(19);
            //contactsService.Delete(20);
            //contactsService.Delete(21);
            //contactsService.Delete(22);
            //contactsService.Delete(23);
            //contactsService.Delete(24);

            foreach (Contact item in connList)
            {
                Console.WriteLine($"First name: {item.FirstName}\nLast name: {item.LastName}\nEmail: {item.Email}\nCategory ID: {item.IdCategory}\n");
            }
            Console.WriteLine();

            #endregion


        }
    }
}
