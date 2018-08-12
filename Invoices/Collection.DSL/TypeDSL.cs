using Collection.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.DAL;

namespace Collection.DSL
{
   public class TypeDSL
    {
        TypeRepo repo = new TypeRepo();

        public IEnumerable<DAL.Type> GetTypes()
        {
            var list = repo.GetTypes();
            return list;

        }
        public DAL.Type GetTypeByID(int id)

        {
            var type = repo.GetTypeByID(id);
            return type;
        }
    }
}
