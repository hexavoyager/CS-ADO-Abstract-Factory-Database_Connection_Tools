using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;
using G = Exo_Recap_1_Console.Global.Services;
using Exo_Recap_1_Console.Client.Mappers;
using Exo_Recap_1_Console.Client.Data;

namespace Exo_Recap_1_Console.Client.Services
{
    class CategoriesService
    {
        private readonly G.CategoriesService _categoriesService;
        public CategoriesService(G.CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        public IEnumerable<Category> Get()
        {
            return _categoriesService.Get().Select(c => c.ToClient());
        }
        public Category Get(int id)
        {
            return _categoriesService.Get(id)?.ToClient();
        }

        public bool Insert(Category category)
        {
            return _categoriesService.Insert(category.ToGlobal());
        }

    }
}
