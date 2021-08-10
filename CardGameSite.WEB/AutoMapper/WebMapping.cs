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

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<CategoryProduct, CategoryProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryProductId));

            CreateMap<User, UserDTO>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));

            CreateMap<UserDTO, User>();
               // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               // .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
