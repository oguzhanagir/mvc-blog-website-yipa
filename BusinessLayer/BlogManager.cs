using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BlogManager
    {
        Repository<Blog> _repoBlog = new Repository<Blog>();

        public List<Blog> GetAll()
        {
            return _repoBlog.List();
        }
    }
}
