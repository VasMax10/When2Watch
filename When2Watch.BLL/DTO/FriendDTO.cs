using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace When2Watch.BLL.DTO
{
    public class FriendDTO
    {
        public int Id { get; set; }
        public string NameGivenByUser { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }
    }
}
