﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace Exo_Recap_1_Console.Global.Repositories
{
    interface ICategoriesRepository 
    {
        void CategoriesService();
        void Get();
        void Get(int id);
        void Insert();
    }
}
