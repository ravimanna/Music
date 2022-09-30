using System.Collections.Generic;
using System.Linq;
using SearchItunes.Domain;

// ReSharper disable All

namespace SearchItunes.Data
{
    public interface IInMemoryRepo
    {
        RepoResponse<ItuneClicks> InsertItuneClick(ItuneClicks newItune);
        RepoResponse<ItuneClicks> AddClick(ItuneClicks updateItune);
        RepoResponse<ItuneClicks> GetItuneClickById(string id);
        List<ItuneClicks> GetAllItuneClicks();
    }

    public class InMemoryRepo : IInMemoryRepo
    {
        private readonly List<ItuneClicks> _ItuneClicks;

        public InMemoryRepo()
        {
            _ItuneClicks = new List<ItuneClicks>();
        }

        public RepoResponse<ItuneClicks> InsertItuneClick(ItuneClicks newItune)
        {
            newItune.TotalClicks = 1;
            _ItuneClicks.Add(newItune);
            return new RepoResponse<ItuneClicks> { Status = RepoResponseStatus.Success, Data = newItune };
        }

        public RepoResponse<ItuneClicks> AddClick(ItuneClicks updateItune)
        {
            var ituneClicks = _ItuneClicks.SingleOrDefault(s => s.Id == updateItune.Id);

            if (ituneClicks != null)
            {
                ituneClicks.TotalClicks = ituneClicks.TotalClicks + 1;
            }

            return new RepoResponse<ItuneClicks> { Status = RepoResponseStatus.Success, Data = ituneClicks };
        }

        public RepoResponse<ItuneClicks> GetItuneClickById(string id)
        {
            var ituneClicks = _ItuneClicks.SingleOrDefault(c => c.Id == id);

            if (ituneClicks == null)
                return new RepoResponse<ItuneClicks> { Status = RepoResponseStatus.RecordNotFound };

            return new RepoResponse<ItuneClicks> { Status = RepoResponseStatus.Success, Data = ituneClicks };
        }

        public List<ItuneClicks> GetAllItuneClicks()
        {
            return _ItuneClicks;
        }
    }
}