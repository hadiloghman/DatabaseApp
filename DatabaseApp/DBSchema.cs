using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp
{

    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        [Column("PostContent")]
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

}
