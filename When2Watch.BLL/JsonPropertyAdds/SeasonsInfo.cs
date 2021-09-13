using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace When2Watch.BLL.JsonPropertyAdds
{
    public class SeasonInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("overview")]
        public string Description { get; set; }

        [JsonPropertyName("season_number")]
        public int Number { get; set; }
    }
    public class SeasonsResults
    {
        [JsonPropertyName("seasons")]
        public List<SeasonInfo> Seasons { get; set; }

    }
}
