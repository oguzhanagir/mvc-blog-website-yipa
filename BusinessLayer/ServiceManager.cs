using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ServiceManager
    {
        Repository<Service> _repoService = new Repository<Service>();

        public List<Service> GetAll()
        {
            return _repoService.List();
        }

        public int AddService(Service p)
        {
            return _repoService.Insert(p);
        }

        public int DeleteService(int p)
        {
            Service service = _repoService.Find(x => x.ServiceID == p);
            return _repoService.Delete(service);
        }

        public int UpdateService(Service p)
        {
            Service service = _repoService.Find(x => x.ServiceID == p.ServiceID);
            service.Title = p.Title;
            service.Content = p.Content;
            service.ServiceID = p.ServiceID;
            service.ImagePath = p.ImagePath;

            return _repoService.Update(service);
        }


    }
}
