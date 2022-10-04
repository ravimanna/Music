using System.Collections.Generic;
using Itunes.Application.Shared;
using Itunes.Domain;
using SearchItunes.Data;

namespace Itunes.Application
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