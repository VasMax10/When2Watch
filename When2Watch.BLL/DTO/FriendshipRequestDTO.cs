using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace When2Watch.BLL.DTO
{
    public class FriendshipRequestDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string FromId { get; set; }
        public string RequestToId { get; set; }


    }
}
