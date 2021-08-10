using AutoMapper;
using CardGameSite.BLL.DTO;
using CardGameSite.WEB.Models;


namespace CardGameSite.WEB.AutoMapper
{
    public class WebMapping : Profile
    {
        public WebMapping()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id)) ;

            CreateMap<CategoryProductDTO, CategoryProduct>()
                .ForMember(dest => dest.CategoryProductId, opt => opt.MapFrom(src => src.Id)); 
        }
    }
}
