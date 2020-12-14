
using Microsoft.EntityFrameworkCore;
using Qdea.Back.Domain;

namespace Qdea.Back.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<IdeaStatus> IdeaStatuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagIdea> TagIdeas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<IdeaInteraction> IdeaInteractions { get; set; }
        public DbSet<IdeaInteractionType> IdeaInteractionTypes { get; set; }
        public DbSet<Effort> Efforts { get; set; }
        public DbSet<Impact> Impacts { get; set; }
        public DbSet<AddedUser> AddedUsers { get; set; }
    }
}