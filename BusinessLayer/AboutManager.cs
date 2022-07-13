using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AboutManager
    {
        Repository<About> _repoAbout = new Repository<About>();

        public List<About> GetAll()
        {
            return _repoAbout.List();
        }

        public int UpdateAbout(About p)
        {
            About about = _repoAbout.Find(x => x.AboutID == p.AboutID);
            about.ContentHome = p.ContentHome;
            about.ContentAbout = p.ContentAbout;
            about.ImagePathHome = p.ImagePathHome;
            about.ImagePathAbout = p.ImagePathAbout;
            about.TitleAbout = p.TitleAbout;
            about.TitleHome = p.TitleHome;
            about.AboutID = p.AboutID;

            return _repoAbout.Update(about);
        }

        public About FindAbout(int id)
        {
            return _repoAbout.Find(x => x.AboutID == id);
        }
    }
}
