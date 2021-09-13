using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace When2Watch.BLL.JsonPropertyAdds
{
    public class EpisodeInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("overview")]
        public string Description { get; set; }

        [JsonPropertyName("episode_number")]
        public int EpisodeNumber { get; set; }

        [JsonPropertyName("air_date")]
        public DateTime ReleaseDate 
        {
            get => _release;
            set
            {
                try
                {
                    _release = value;
                }
                catch(Exception e)
                {
                    _release = DateTime.Parse("1900-01-01");
                }
            }
        }
        private DateTime _release;
    }
    public class EpisodesResults
    {
        [JsonPropertyName("episodes")]
        public List<EpisodeInfo> Episodes { get; set; }

    }
}
