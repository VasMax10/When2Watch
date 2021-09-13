using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace When2Watch.BLL.DTO
{
    public class EpisodeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int SeasonId { get; set; }

    }
}
