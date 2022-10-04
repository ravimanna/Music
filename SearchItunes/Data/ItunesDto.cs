using System.Collections.Generic;
using Itunes.Domain;

namespace Itunes.Data
{
    public class ItunesDto
    {
        public int ResultCount { get; set; }
        public IEnumerable<Itune> Results { get; set; }
    }
}