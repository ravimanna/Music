using System.Diagnostics;
using Itunes.Application.Shared;
using Itunes.Domain;
using Itunes.Models;
using SearchItunes.Data;

namespace Itunes.Application
{
    public interface IRecordClick
    {
        TransactionResponse<ItuneClicks> Execute(ItunesViewModel itunesViewModel);
    }

    public class RecordClick : IRecordClick
    {
        private readonly IInMemoryRepo _inMemoryRepo;

        public RecordClick(IInMemoryRepo inMemoryRepo)
        {
            _inMemoryRepo = inMemoryRepo;
        }

        public TransactionResponse<ItuneClicks> Execute(ItunesViewModel itunesViewModel)
        {

            Process.Start(new ProcessStartInfo
            {
                FileName = itunesViewModel.CollectionViewUrl,
                UseShellExecute = true
            });

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