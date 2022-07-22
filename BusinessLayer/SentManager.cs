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

        public List<Sent> SentByID(int id)
        {
            return _repoSent.List(x => x.SentID == id);
        }

        public int DeleteSent(int id)
        {
            Sent sent = _repoSent.Find(x => x.SentID == id);
            return _repoSent.Delete(sent);
        }

    }
}
