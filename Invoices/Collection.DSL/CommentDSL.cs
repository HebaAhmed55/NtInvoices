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
    public class CommentDSL
    {
        CommentRepo repo = new CommentRepo();

        public IEnumerable<Comment> GetComments()
        {
            var list = repo.GetComments();
            return list;

        }
        public Comment GetCommentByID(int id)

        {
            var comment = repo.GetCommentByID(id);
            return comment;
        }

        public void InsertComment(Comment comment)
        {

            repo.InsertComment(comment);
        }

        public void CommitComment()
        {
            repo.CommitComment();
        }
    }
}
