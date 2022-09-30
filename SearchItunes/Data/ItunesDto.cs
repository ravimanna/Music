using System.Collections.Generic;
using SearchItunes.Domain;

namespace SearchItunes.Data
{
    public class ItunesDto
    {
        public int ResultCount { get; set; }
        public IEnumerable<Itune> Results { get; set; }
    }
}