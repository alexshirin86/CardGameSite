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


        public ProductService(IUnitOfWork<Product> uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {

            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Database.Repository.GetAll());
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id товара", "");
            var product = Database.Repository.Get(id.Value);
            if (product == null)
                throw new ValidationException("Товар не найден", "");

            return new ProductDTO { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price, Category = product.Category };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }

}
