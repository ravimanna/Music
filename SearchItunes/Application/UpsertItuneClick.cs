using SearchItunes.Application.Shared;
using SearchItunes.Data;
using SearchItunes.Domain;
using SearchItunes.Models;

namespace SearchItunes.Application
{
    public interface IUpsertItuneClick
    {
        TransactionResponse<ItuneClicks> Execute(ItunesViewModel itunesViewModel);
    }

    public class UpsertItuneClick : IUpsertItuneClick
    {
        private readonly IInMemoryRepo _inMemoryRepo;

        public UpsertItuneClick(IInMemoryRepo inMemoryRepo)
        {
            _inMemoryRepo = inMemoryRepo;
        }

        public TransactionResponse<ItuneClicks> Execute(ItunesViewModel itunesViewModel)
        {
            var response = _inMemoryRepo.GetItuneClickById(itunesViewModel.Id);

            return response.Data != null
                ? TransactionResponse.Ok(_inMemoryRepo.AddClick(response.Data).Data, "")
                : TransactionResponse.Created(_inMemoryRepo
                    .InsertItuneClick(new ItuneClicks
                    {
                        Id = itunesViewModel.Id,
                        Kind = itunesViewModel.Kind,
                        ArtistName = itunesViewModel.ArtistName,
                        TrackName = itunesViewModel.TrackName,
                        CollectionName = itunesViewModel.CollectionName,
                        CollectionViewUrl = itunesViewModel.CollectionViewUrl,
                        TotalClicks = 1
                    }).Data);
        }
    }
}