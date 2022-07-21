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

        public int AddBlog(Blog p)
        {
            return _repoBlog.Insert(p);
        }

        public int DeleteBlog(int p)
        {
            Blog blog = _repoBlog.Find(x => x.BlogID == p);
            return _repoBlog.Delete(blog);
        }

        public int UpdateBlog(Blog p)
        {
            Blog blog = _repoBlog.Find(x => x.BlogID == p.BlogID);
            blog.Title = p.Title;
            blog.Content = p.Content;
            if (p.ImagePath != "")
            {
                blog.ImagePath = p.ImagePath;
            }

            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            blog.BlogID = p.BlogID;
        
            return _repoBlog.Update(blog);
        }

        public int BlogCount()
        {
            return _repoBlog.List().Count();
        }

        public Blog FindBlog(int id)
        {
            return _repoBlog.Find(x => x.BlogID == id);
        }

        public List<Blog> BlogByID(int id)
        {
            return _repoBlog.List(x => x.BlogID == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return _repoBlog.List(x => x.CategoryID == id);
        }

    }
}
