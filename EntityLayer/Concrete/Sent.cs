using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sent
    {
        [Key]
        public int SentID { get; set; }

        [StringLength(40)]
        public string ToMail { get; set; }

        [StringLength(120)]
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
