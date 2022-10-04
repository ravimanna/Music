using System.Collections.Generic;
using Itunes.Application.Shared;
using Itunes.Domain;
using SearchItunes.Data;

namespace Itunes.Application
{
    public interface IGetClicks
    {
        public TransactionResponse<List<ItuneClicks>> Execute();
    }

    public class GetClicks : IGetClicks
    {
        private readonly IInMemoryRepo _inMemoryRepo;

        public GetClicks(IInMemoryRepo inMemoryRepo)
        {
            _inMemoryRepo = inMemoryRepo;
        }

        public TransactionResponse<List<ItuneClicks>> Execute()
        {
            return TransactionResponse.Ok(_inMemoryRepo.GetAllItuneClicks(), "");
        }
    }
}