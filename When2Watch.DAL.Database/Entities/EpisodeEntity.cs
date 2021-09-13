using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace When2Watch.DAL.Database.Entities
{
    public class EpisodeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }

        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public virtual SeasonEntity Season { get; set; }

        public ICollection<EpisodeStatusEntity> EpisodeStatuses { get; set; }

    }
}
