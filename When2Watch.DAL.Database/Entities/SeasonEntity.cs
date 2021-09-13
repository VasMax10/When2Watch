using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace When2Watch.DAL.Database.Entities
{
    public class SeasonEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeasonNumber { get; set; }
        public string Description { get; set; }

        [ForeignKey("Series")]
        public int SeriesId { get; set; }
        public SeriesEntity Series { get; set; }

        public ICollection<EpisodeEntity> Episodes { get; set; }
    }
}
