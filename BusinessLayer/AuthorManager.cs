using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AuthorManager
    {
        Repository<Author> _repoAuthor = new Repository<Author>();

        public List<Author> GetAll()
        {
            return _repoAuthor.List();
        }

        public int AddAuthor(Author p)
        {
            return _repoAuthor.Insert(p);
        }

        public int DeleteAuthor(int p)
        {
            Author author = _repoAuthor.Find(x => x.AuthorID == p);
            return _repoAuthor.Delete(author);
        }

        public int UpdateAuthor(Author p)
        {
            Author author = _repoAuthor.Find(x => x.AuthorID == p.AuthorID);
            return _repoAuthor.Update(author);
        }

        public int CountAuthor()
        {
            return _repoAuthor.List().Count();
        }

    }
}
