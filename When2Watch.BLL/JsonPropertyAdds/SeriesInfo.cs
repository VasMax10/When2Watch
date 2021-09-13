using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace When2Watch.BLL.JsonPropertyAdds
{
    public class SeriesInfo
    {
        [JsonPropertyName("name")]
        public string Title { get; set; }

        [JsonPropertyName("overview")]
        public string Description { get; set; }

        [JsonPropertyName("id")]
        public int TmdbId { get; set; }

        [JsonPropertyName("vote_average")]
        public decimal RatingImdb { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
    }
    public class TVSeries
    {
        [JsonPropertyName("results")]
        public List<SeriesInfo> Results { get; set; }

    }
}
