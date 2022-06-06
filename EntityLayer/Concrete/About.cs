using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        [StringLength(50)]
        public string TitleHome { get; set; }

        [StringLength(500)]
        public string ContentHome { get; set; }
        
        [StringLength(100)]
        public string ImagePathHome { get; set; }
        
        [StringLength(50)]
        public string TitleAbout { get; set; }

        [StringLength(500)]
        public string ContentAbout { get; set; }

        [StringLength(100)]
        public string ImagePathAbout { get; set; }
        
    }
}
