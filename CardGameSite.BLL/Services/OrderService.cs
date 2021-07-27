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
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Product product = Database.Products.Get(orderDto.ProductId);

            if (product == null)
                throw new ValidationException("Телефон не найден", "");

            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                ProductId = product.Id,
                Sum = product.Price,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id товара", "");
            var phone = Database.Products.Get(id.Value);
            if (phone == null)
                throw new ValidationException("Товар не найден", "");

            return new ProductDTO { Company = phone.Company, Id = phone.Id, Name = phone.Name, Price = phone.Price };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }

}
