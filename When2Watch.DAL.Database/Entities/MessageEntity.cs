using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace When2Watch.DAL.Database.Entities
{
    public class MessageEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("Series")]
        public int SeriesId { get; set; }
        public virtual SeriesEntity Series { get; set; }

        [ForeignKey("Friend")]
        public int FriendId { get; set; }
        public virtual FriendEntity Friend { get; set; }

    }
}
