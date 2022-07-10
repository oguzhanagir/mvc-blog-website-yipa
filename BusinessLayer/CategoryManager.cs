using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager
    {
        Repository<Category> _repoCategory = new Repository<Category>();

        public List<Category> GetAll()
        {
            return _repoCategory.List();
        }

        public int AddCategory(Category p)
        {
            return _repoCategory.Insert(p);
        }

        public int DeleteCategory(int p)
        {
            Category category = _repoCategory.Find(x => x.CategoryID == p);
            return _repoCategory.Delete(category);
        }

        public int UpdateCategory(Category p)
        {
            Category category = _repoCategory.Find(x => x.CategoryID == p.CategoryID);
            category.CategoryID = p.CategoryID;
            category.Name = p.Name;

            return _repoCategory.Update(category);

        }

        public int CategoryCount()
        {
            return _repoCategory.List().Count();
        }

        public Category FindCategory(int id)
        {
            return _repoCategory.Find(x => x.CategoryID == id);
        }
    }
}
