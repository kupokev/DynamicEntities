using System;

namespace DynamicEntityFilter.Model.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Posted { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
