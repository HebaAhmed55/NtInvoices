using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Collection.DAL;

namespace Collection.Repository
{
   public class TypeRepo
    {
        public static InvoicesEntities2 context = new InvoicesEntities2();

        public IEnumerable<DAL.Type> GetTypes()
        {
            return context.Types.ToList();
        }

        public DAL.Type GetTypeByID(int id)
        {
            return context.Types.Find(id);
        }

        
    }
}
