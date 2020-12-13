
using Microsoft.EntityFrameworkCore;
using Qdea.API.Domain;

namespace Qdea.API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CostSaving> CostSavings { get; set; }
        public DbSet<IdeaStatus> IdeaStatuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagIdea> TagIdeas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserIdea> UserIdeas { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }

    }
}