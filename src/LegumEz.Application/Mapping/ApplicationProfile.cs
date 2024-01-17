using AutoMapper;
using LegumEz.Application.Cultures;
using LegumEz.Domain.Cultures;

namespace LegumEz.Application.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Culture, CultureDto>();
        }
    }
}
