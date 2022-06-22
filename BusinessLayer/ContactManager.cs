using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ContactManager
    {
        Repository<Contact> _repoContact = new Repository<Contact>();

        public List<Contact> GetAll()
        {
            return _repoContact.List();
        }

        public int AddContact(Contact p)
        {
            return _repoContact.Insert(p);
        }

        public int DeleteContact(int p)
        {
            Contact contact = _repoContact.Find(x => x.ContactID == p);
            return _repoContact.Delete(contact);
        }
    }
}
