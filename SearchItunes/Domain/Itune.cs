using System;
using System.Collections.Generic;

namespace Itunes.Domain
{
    public class Itune
    {
        public string Id => ArtistId + TrackId.ToString() + CollectionId;
        public string WrapperType { get; set; }
        public string Kind { get; set; }
        public int ArtistId { get; set; }
        public int CollectionId { get; set; }
        public int TrackId { get; set; }
        public string ArtistName { get; set; }
        public string CollectionName { get; set; }
        public string TrackName { get; set; }
        public string CollectionCensoredName { get; set; }
        public string TrackCensoredName { get; set; }
        public string ArtistViewUrl { get; set; }
        public string CollectionViewUrl { get; set; }
        public string FeedUrl { get; set; }
        public string TrackViewUrl { get; set; }
        public string ArtworkUrl30 { get; set; }
        public string ArtworkUrl60 { get; set; }
        public string ArtworkUrl100 { get; set; }
        public double CollectionPrice { get; set; }
        public double TrackPrice { get; set; }
        public int TrackRentalPrice { get; set; }
        public int CollectionHdPrice { get; set; }
        public int TrackHdPrice { get; set; }
        public int TrackHdRentalPrice { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CollectionExplicitness { get; set; }
        public string TrackExplicitness { get; set; }
        public int TrackCount { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string PrimaryGenreName { get; set; }
        public string ContentAdvisoryRating { get; set; }
        public string ArtworkUrl600 { get; set; }
        public List<string> GenreIds { get; set; }
        public List<string> Genres { get; set; }
        public string PreviewUrl { get; set; }
        public int? DiscCount { get; set; }
        public int? DiscNumber { get; set; }
        public int? TrackNumber { get; set; }
        public int? TrackTimeMillis { get; set; }
        public bool? IsStreamable { get; set; }
        public int? AmgArtistId { get; set; }
        public string Copyright { get; set; }
        public string Description { get; set; }
        public int? CollectionArtistId { get; set; }
        public string CollectionArtistName { get; set; }
        public string CollectionArtistViewUrl { get; set; }
    }
}