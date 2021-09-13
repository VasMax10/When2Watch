using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace When2Watch.BLL.DTO
{
    public class SeriesDTO
    {
        public int Id { get; set; }
        public int TmdbId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal RatingIMDb { get; set; }
        public DateTime LastSync { get; set; }
        public string PosterPath { get; set; }
    }
}
