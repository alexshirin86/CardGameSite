using AutoMapper;
using CardGameSite.BLL.DTO;
using CardGameSite.DAL.Entities;

namespace CardGameSite.BLL.AutoMapper
{
    public class BllMapping : Profile
    {
        public BllMapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CategoryProduct, CategoryProductDTO>().ReverseMap(); 
            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
