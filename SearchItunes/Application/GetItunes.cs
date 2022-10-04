using System.Collections.Generic;
using System.Linq;
using Itunes.Application.Shared;
using Itunes.Data;
using Itunes.Models;
using SearchItunes.Data;

namespace Itunes.Application
{
    public interface IGetItunes
    {
        TransactionResponse<IEnumerable<ItunesViewModel>> Execute(ResourceParameters parameters);
    }

    public class GetItunes : IGetItunes
    {
        private readonly IInMemoryRepo _inMemoryRepo;
        private readonly IRestRepo _restRepo;

        public GetItunes(IRestRepo restRepo, IInMemoryRepo inMemoryRepo)
        {
            _restRepo = restRepo;
            _inMemoryRepo = inMemoryRepo;
        }

        public TransactionResponse<IEnumerable<ItunesViewModel>> Execute(ResourceParameters parameters)
        {
            var response = _restRepo.GetItunes(parameters.SearchTerm);

            var ituneClicks = _inMemoryRepo.GetAllItuneClicks();

            var viewModel = response.Data.Results
                .GroupJoin(ituneClicks,
                    itune => itune.Id,
                    clicks => clicks.Id,
                    (itune, clicks) => new { itune, clicks })
                .SelectMany(
                    x => x.clicks.DefaultIfEmpty(),
                    (a, b) => new ItunesViewModel
                    {
                        Id = a.itune.Id,
                        CollectionName = a.itune.CollectionName,
                        ArtistName = a.itune.ArtistName,
                        Kind = a.itune.Kind,
                        TrackName = a.itune.TrackName,
                        CollectionViewUrl = a.itune.CollectionViewUrl,
                        TotalClicks = b?.TotalClicks ?? 0
                    }
                );

            return !response.Data.Results.Any()
                ? TransactionResponse.NotFound(viewModel, "")
                : TransactionResponse.Ok(viewModel, "");
        }
    }
}