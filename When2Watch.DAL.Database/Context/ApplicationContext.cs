using Microsoft.EntityFrameworkCore;
using When2Watch.DAL.Database.Entities;

namespace When2Watch.DAL.Database.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FriendshipRequestEntity> FriendshipRequests { get; set; }
        public DbSet<FriendEntity> Friends { get; set; }
        public DbSet<SeasonEntity> Seasons { get; set; }
        public DbSet<SeriesEntity> Series { get; set; }
        public DbSet<WatchlistEntity> Watchlists { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<EpisodeEntity> Episodes { get; set; }
        public DbSet<EpisodeStatusEntity> EpisodeStatuses { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
