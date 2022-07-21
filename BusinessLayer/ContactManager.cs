using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        public string  SendMessage()
        {
            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                // Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress("yipasendmail@gmail.com", "YipaBlog");

                newMail.To.Add("yipasendmail@gmail.com");// declare the email subject

                newMail.Subject = "My First Email"; // use HTML for the email body

                newMail.IsBodyHtml = true; newMail.Body =
                    "<h1> This is my first Templated Email in C# </h1>";

                // enable SSL for encryption across channels
                client.EnableSsl = true;
                // Port 465 for SSL communication
                client.Port = 465;
                // Provide authentication information with Gmail SMTP server to authenticate your sender account
                client.Credentials = new System.Net.NetworkCredential("yipasendmail@gmail.com", "142536oA.");

                client.Send(newMail); // Send the constructed mail
                return "Başarılı";
            }
            catch (Exception ex)
            {
                return "Error -" + ex ;
            }
        }


    }
}
