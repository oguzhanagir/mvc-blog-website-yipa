using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string Mail { get; set; }

        [StringLength(500)]
        public string Text { get; set; }

        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
