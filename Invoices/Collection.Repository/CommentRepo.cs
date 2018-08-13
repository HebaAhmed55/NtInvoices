using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Collection.DAL;
using System.Linq;
using System.Collections.Generic;
namespace Collection.Repository
{
     public class CommentRepo
    {
        public static InvoicesEntities2 context4 = new InvoicesEntities2();

        public List<Comment> GetComments()
        {
            var comments = context4.Comments.Include(c => c.Invoice).Include(c => c.User);

            return context4.Comments.ToList();
        }

        public Comment GetCommentByID(int id)
        {
            return context4.Comments.Find(id);
        }

        public void InsertComment(Comment comment)
        {
            context4.Comments.Add(comment);
        }

        public void CommitComment()
        {
            context4.SaveChanges();
        }
    }
}

