using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace When2Watch.DAL.Database.Entities
{
    public class FriendEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameGivenByUser { get; set; }
        public string UserId { get; set; }

        [ForeignKey("FriendProfile")]
        public int FriendId { get; set; }
        public virtual UserEntity FriendProfile { get; set; }

        public ICollection<MessageEntity> Messages { get; set; }
    }
}
