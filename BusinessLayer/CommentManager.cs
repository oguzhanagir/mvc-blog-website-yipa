using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CommentManager
    {
        Repository<Comment> _repoComment = new Repository<Comment>();

        public List<Comment> GetAll()
        {
            return _repoComment.List();
        }

        public int AddComment(Comment p)
        {
            return _repoComment.Insert(p);
        }

        public int DeleteComment(int p)
        {
            Comment comment = _repoComment.Find(x => x.CommentID == p);
            return _repoComment.Delete(comment);
        }

        public int CommentCount()
        {
            return _repoComment.List().Count();
        }

        
    }
}
