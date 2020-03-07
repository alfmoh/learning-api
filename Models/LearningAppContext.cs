using Microsoft.EntityFrameworkCore;

namespace LearningApi.Models
{
    public partial class LearningAppContext : DbContext
    {

        public LearningAppContext(DbContextOptions<LearningAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> PostsDB { get; set; }
        public virtual DbSet<Tag> TagsDB { get; set; }

    }
}
