using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int? ReplyTo { get; set; }
        public int SeriesId { get; set; }
        public int ClientId { get; set; }
        public string Author { get; set; }

        public CommentViewModel(CommentDTO comment, string author)
        {
            Id = comment.Id;
            Text = comment.Text;
            DateTime = comment.DateTime;
            ReplyTo = comment.ReplyTo;
            SeriesId = comment.SeriesId;
            ClientId = comment.ClientId;
            Author = author.Substring(0, author.IndexOf("@"));
        }
    }
}
