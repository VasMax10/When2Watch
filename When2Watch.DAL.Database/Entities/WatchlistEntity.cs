using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace When2Watch.DAL.Database.Entities
{
    public class WatchlistEntity
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public double UserRating { get; set; }
        
        [ForeignKey("Series")]
        public int SeriesId { get; set; }
        public virtual SeriesEntity Series { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        //public ICollection<EpisodeStatusEntity> EpisodeStatuses { get; set; }
    }
}
