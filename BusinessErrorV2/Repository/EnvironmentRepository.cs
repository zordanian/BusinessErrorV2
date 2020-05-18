using BusinessErrorV2.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessErrorV2.Repository
{
    class EnvironmentRepository
    {
        private UiPathEntities db;

        public EnvironmentRepository()
        {
            this.db = new UiPathEntities();

        }

        public IEnumerable<string> getProcessNames()
        {


            return null;
        }

    }

   

}
