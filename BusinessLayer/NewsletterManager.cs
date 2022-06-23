using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class NewsletterManager
    {
        Repository<Newsletter> _repoNewsletter = new Repository<Newsletter>();

        public int AddNewslterr(Newsletter p)
        {
            if (p.Mail.Length<=10 || p.Mail.Length >=30)
            {
                return -1;
            }

            return _repoNewsletter.Insert(p);
        }

        public List<Newsletter> GetAll()
        {
            return _repoNewsletter.List();
        }

        public int DeleteNewsletter(int p)
        {
            Newsletter newsletter = _repoNewsletter.Find(x=>x.NewsletterId == p);
            return _repoNewsletter.Delete(newsletter);

        }
    }
}
