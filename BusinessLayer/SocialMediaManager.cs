using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SocialMediaManager
    {
        Repository<SocialMedia> _repoSocial = new Repository<SocialMedia>();

        public List<SocialMedia> GetAll()
        {
            return _repoSocial.List();
        }

        public int AddSocialMedia(SocialMedia p)
        {
            return _repoSocial.Insert(p);
        }
        public int DeleteSocialMedia(int p)
        {
            SocialMedia socialMedia = _repoSocial.Find(x => x.SocialMediaID == p);
            return _repoSocial.Delete(socialMedia);
        }

        public int UpdateSocialMedia(SocialMedia p)
        {
            SocialMedia socialMedia = _repoSocial.Find(x => x.SocialMediaID == p.SocialMediaID);
            socialMedia.IconPath = p.IconPath;
            socialMedia.Name = p.Name;
            socialMedia.Address = p.Address;
            socialMedia.SocialMediaID = p.SocialMediaID;
            return _repoSocial.Update(socialMedia);
        }

        public SocialMedia FindSocialMedia(int id)
        {
            return _repoSocial.Find(x => x.SocialMediaID == id);
        }


    }
}
