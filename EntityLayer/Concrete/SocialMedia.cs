using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaID { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(80)]
        public string Address { get; set; }

    }
}
