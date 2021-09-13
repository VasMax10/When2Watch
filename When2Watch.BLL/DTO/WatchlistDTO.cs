namespace When2Watch.BLL.DTO
{
    public class WatchlistDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public double UserRating { get; set; }
        public int SeriesId { get; set; }
        public string UserId { get; set; }
    }
}
