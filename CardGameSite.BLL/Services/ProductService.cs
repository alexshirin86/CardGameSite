using System;
using CardGameSite.BLL.DTO;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.Interfaces;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace CardGameSite.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork<Product> Database { get; set; }

        private IMapper _mapper;


        public ProductService(IUnitOfWork<Product> puow, IMapper mapper)
        {
            Database = puow;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {

            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Database.Repository.GetAll());
        }

        public ProductDTO GetProduct(int? idProduct)
        {
            if (idProduct == null)
                throw new ValidationException("Не установлено id товара", "");
            var product = Database.Repository.Get(idProduct.Value);
            if (product == null)
                throw new ValidationException("Товар не найден", "");

            return new ProductDTO { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price, Categories = _mapper.Map<List<CategoryProduct>, List<CategoryProductDTO>>(product.Categories) };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }

}
