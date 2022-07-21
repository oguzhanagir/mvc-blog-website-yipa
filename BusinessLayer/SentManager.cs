using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SentManager
    {
        Repository<Sent> _repoSent = new Repository<Sent>();

        public List<Sent> GetAll()
        {
            return _repoSent.List();
        }

        public int AddSent(Sent p)
        {
            return _repoSent.Insert(p);
        }
    }
}
