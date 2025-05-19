using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Repo
    {
        protected Class_TestEntities db;
        public Repo()
        {
            db = new Class_TestEntities();
        }
    }
}
