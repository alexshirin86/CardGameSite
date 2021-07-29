using AutoMapper;
using CardGameSite.BLL.DTO;
using CardGameSite.WEB.Models;


namespace CardGameSite.WEB.AutoMapper
{
    public class WebMapping : Profile
    {
        public WebMapping()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<CategoryProductDTO, CategoryProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
