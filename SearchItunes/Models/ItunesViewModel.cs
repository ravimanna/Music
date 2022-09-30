namespace SearchItunes.Models
{
    public class ItunesViewModel
    {
        public string Id { get; set; }
        public string Kind { get; set; }
        public string ArtistName { get; set; }
        public string CollectionName { get; set; }
        public string TrackName { get; set; }
        public string CollectionViewUrl { get; set; }
        public int TotalClicks { get; set; } = 0;
    }
}