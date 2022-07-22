
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace BusinessLayer
{
    public class ContactManager
    {
        Repository<Contact> _repoContact = new Repository<Contact>();

        public List<Contact> GetAll()
        {
            return _repoContact.List();
        }

        public int AddContact(Contact c)
        {
            return _repoContact.Insert(c);
        }

        public int DeleteContact(int p)
        {
            Contact contact = _repoContact.Find(x => x.ContactID == p);
            return _repoContact.Delete(contact);
        }

        public List<Contact> ContactByID(int id)
        {
            return _repoContact.List(x => x.ContactID == id);
        }
        
        public void SendMessage(string mail, string subject, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient client = new SmtpClient();

                client.Credentials = new System.Net.NetworkCredential("yipasend@hotmail.com", "142536oA.1");

                client.Port = 587;

                client.Host = "smtp-mail.outlook.com";

                client.EnableSsl = true;

                mailMessage.To.Add(mail);

                mailMessage.From = new MailAddress("yipasend@hotmail.com");

                mailMessage.Subject = subject;

                mailMessage.Body = message;

                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
