using System;

namespace When2Watch.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime{ get; set; }
        public int? ReplyTo { get; set; }
        public int SeriesId { get; set; }
        public int ClientId { get; set; }
    }
}
