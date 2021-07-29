using AutoMapper;
using CardGameSite.BLL.DTO;
using CardGameSite.DAL.Entities;

namespace CardGameSite.BLL.AutoMapper
{
    public class BllMapping : Profile
    {
        public BllMapping()
        {
            CreateMap<Product, ProductDTO>();
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                //.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
                //.AfterMap((src, dest) => {
                //    foreach (var c in dest.Categories)
                //    {
                //        c.ProductId = src.Id;
                //    }
           // });

            CreateMap<CategoryProduct, CategoryProductDTO>();
                //.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src)); ;
        }        
    }
}
