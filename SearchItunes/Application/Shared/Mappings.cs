using AutoMapper;
using SearchItunes.Domain;
using SearchItunes.Models;

namespace SearchItunes.Application.Shared
{
    public class Mappings : Profile
    {
        //Coming soon
        public Mappings()
        {
            CreateMap<Itune, ItunesViewModel>();
        }
    }
}