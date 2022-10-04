using AutoMapper;
using Itunes.Domain;
using Itunes.Models;

namespace Itunes.Application.Shared
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