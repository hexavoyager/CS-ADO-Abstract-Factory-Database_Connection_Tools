using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace Exo_Recap_1_Console
{
    interface GIContactRepository
    {
        void ContactsService();
        void Get();
        void GetByCategory();
        void Get(int id);
        void Insert();
        void Update();
        void Delete();

    }
}
