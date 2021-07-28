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
        }
    }
}
