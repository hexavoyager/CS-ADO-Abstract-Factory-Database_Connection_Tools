using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;
using GCategoriesService = Exo_Recap_1_Console.CategoriesService;
using Exo_Recap_1_Console.Client.Mappers;
using C = Exo_Recap_1_Console.Client.Data;

namespace Exo_Recap_1_Console.Client.Services
{
    class CategoriesService
    {
        private readonly GCategoriesService _categoriesService;
        public CategoriesService(GCategoriesService categoriesService)
        {
            categoriesService = _categoriesService;
        }
        public IEnumerable<C.Category> Get()
        {
            return _categoriesService.Get().Select(c => c.ToClient());
        }
        public C.Category Get(int id)
        {
            return _categoriesService.Get(id)?.ToClient();
        }

        public bool Insert(Category category)
        {
            return _categoriesService.Insert(category);
        }

    }
}
