using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace When2Watch.DAL.Database.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public bool Searchable { get; set; }

        public ICollection<WatchlistEntity> Watchlists { get; set; }
        public ICollection<EpisodeStatusEntity> EpisodeStatuses { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<UserEntity> Friends { get; set; }
        public ICollection<FriendshipRequestEntity> Requests { get; set; }

    }
}
