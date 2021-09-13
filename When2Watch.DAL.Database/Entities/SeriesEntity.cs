using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace When2Watch.DAL.Database.Entities
{
    public class SeriesEntity
    {
        [Key]
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal RatingIMDb { get; set; }
        public string PosterPath { get; set; }
        public DateTime LastSync { get; set; }

        public ICollection<WatchlistEntity> Watchlists { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<SeasonEntity> Seasons { get; set; }
        public ICollection<MessageEntity> Messages { get; set; }
    }
}
