using System;
using System.Collections.Generic;

namespace DynamicEntityFilter.Model.Entities
{
    public class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
