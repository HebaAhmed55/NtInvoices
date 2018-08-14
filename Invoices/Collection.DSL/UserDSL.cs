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
    public class UserDSL
    {
        UserRepo repo = new UserRepo();

        public List<User> GetUsers()
        {
            var list2 = repo.GetUsers();
            return list2;

        }
        public User GetUserByID(int id)

        {
            var user = repo.GetUserByID(id);
            return user;
        }
        public int login(User user)

        {
            return repo.login(user);
        }

       
        
        public void InsertUser(User user)
        {
            List<User> list = repo.GetUsers();
            int Count = list.Count();
            foreach (var o in list)
            {
                if (o.UserNo >= Count) { Count = o.UserNo + 1; }
            }
            user.UserNo = Count ;
          repo.InsertUser(user);
        }

        public void DeleteUser(int id)
        {
            repo.DeleteUser(id);
        }

        public void UpdateUser(User user)
        {
            repo.UpdateUser(user);
        }
        public void CommitUser()
        {
            repo.CommitUser();
        }
    }
}
