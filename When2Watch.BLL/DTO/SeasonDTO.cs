using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace When2Watch.BLL.DTO
{
    public class SeasonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeasonNumber { get; set; }
        public string Description { get; set; }
        public int SeriesId { get; set; }
    }
}
