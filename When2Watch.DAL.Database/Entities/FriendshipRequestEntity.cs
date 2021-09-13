using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace When2Watch.DAL.Database.Entities
{
    public class FriendshipRequestEntity
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public int FromId { get; set; }

        [ForeignKey("RequestTo")]
        public int RequestToId { get; set; }
        public virtual UserEntity RequestTo { get; set; }


    }
}
