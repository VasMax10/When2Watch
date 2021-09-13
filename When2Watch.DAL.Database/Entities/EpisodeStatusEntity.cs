using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace When2Watch.DAL.Database.Entities
{
    public class EpisodeStatusEntity
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }

        [ForeignKey("Episode")]
        public int EpisodeId { get; set; }
        public EpisodeEntity Episode { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
