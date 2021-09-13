using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace When2Watch.BLL.DTO
{
    public class EpisodeStatusDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int EpisodeId { get; set; }
        public int UserId { get; set; }
    }
}
