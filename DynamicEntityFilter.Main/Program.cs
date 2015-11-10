using Data;
using DynamicEntityFilter.Filter;
using System.Linq;

namespace DynamicEntityFilter.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MainModel())
            {
                var posts = context.Posts.AsNoTracking().Filter("Title", "lorem ipsum").ToList();

                System.Console.WriteLine("Field filtered on: {0}, Value filtered on: {1} ");
                foreach (var post in posts)
                {
                    System.Console.WriteLine("Blog ID: {0}, Post ID: {1}", post.BlogId.ToString(), post.PostId.ToString());
                }
            }
        }
    }
}
