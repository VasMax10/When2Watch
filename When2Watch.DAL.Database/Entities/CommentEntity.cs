using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace When2Watch.DAL.Database.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime{ get; set; }
        public int? ReplyTo { get; set; }


        [ForeignKey("Series")]
        public int SeriesId { get; set; }
        public virtual SeriesEntity Series { get; set; }

        [ForeignKey("ClientProfile")]
        public int ClientId { get; set; }
        public virtual UserEntity ClientProfile { get; set; }
    }
}
