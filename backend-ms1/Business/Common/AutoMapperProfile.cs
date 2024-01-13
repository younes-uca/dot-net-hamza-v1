using AutoMapper;
using Stocky.Models;
using Stocky.Models.DTO;
using Stocky.Models.Dtos;
using Stocky.Zynerator.Models;
using Stocky.Zynerator.Models.Dtos;

namespace Stocky.Business.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Produit, ProduitDto>();
            CreateMap<ProduitDto, Produit>();
            CreateMap<Achat, AchatDto>();
            CreateMap<AchatDto, Achat>();
            CreateMap<AchatItem, AchatItemDto>();
            CreateMap<AchatItemDto, AchatItem>();

            CreateMap<UserDto, User>()
            .ForMember(pts => pts.Name, opt => opt.MapFrom(ps => ps.Nom))
            .ForMember(pts => pts.famillyName, opt => opt.MapFrom(ps => ps.Prenom));

            CreateMap<User, UserDto>()
            .ForMember(pts => pts.Nom, opt => opt.MapFrom(ps => ps.Name))
            .ForMember(pts => pts.Prenom, opt => opt.MapFrom(ps => ps.famillyName));

        }
    }
}
