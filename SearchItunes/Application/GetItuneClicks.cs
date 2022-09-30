using System.Collections.Generic;
using SearchItunes.Application.Shared;
using SearchItunes.Data;
using SearchItunes.Domain;

namespace SearchItunes.Application
{
    public interface IGetItuneClicks
    {
        public TransactionResponse<List<ItuneClicks>> Execute();
    }

    public class GetItuneClicks : IGetItuneClicks
    {
        private readonly IInMemoryRepo _inMemoryRepo;

        public GetItuneClicks(IInMemoryRepo inMemoryRepo)
        {
            _inMemoryRepo = inMemoryRepo;
        }

        public TransactionResponse<List<ItuneClicks>> Execute()
        {
            return TransactionResponse.Ok(_inMemoryRepo.GetAllItuneClicks(), "");
        }
    }
}