using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Collection.DAL;
using System.Linq;
using System.Collections.Generic;

namespace Collection.Repository
{
    public class UserRepo
    {
        public static InvoicesEntities2 context3 = new InvoicesEntities2();

        public List<User> GetUsers()
        {
            var users = context3.Users.Include(u => u.Type);
            return context3.Users.ToList();
        }

        public User GetUserByID(int id)
        {
            return context3.Users.Find(id);
        }

        public bool login(User user)
        {
            var obj = context3.Users.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
            if (obj != null)
            {
                return true;
            }
            return false;
        }
        public void InsertUser(User user)
        {
            context3.Users.Add(user);
            context3.SaveChanges();
        }

        public void DeleteUser(int UserId)
        {
            User user = context3.Users.Find(UserId);
            context3.Users.Remove(user);

        }


        public void UpdateUser(User user)
        {

            var c = context3.Users.FirstOrDefault(d => d.UserId == user.UserId);

            context3.Users.FirstOrDefault(d => d.UserId == user.UserId).Active = user.Active;
            context3.Users.FirstOrDefault(d => d.UserId == user.UserId).Name = user.Name;
            context3.Users.FirstOrDefault(d => d.UserId == user.UserId).UserName = user.UserName;
            context3.Users.FirstOrDefault(d => d.UserId == user.UserId).Password = user.Password;
            context3.Users.FirstOrDefault(d => d.UserId == user.UserId).Type_id = user.Type_id;

            
            CommitUser();
        }

        public void CommitUser()
        {
            context3.SaveChanges();
        }
    }
}
