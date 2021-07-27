using System;
using CardGameSite.BLL.DTO;
using CardGameSite.DAL.Entities;
using CardGameSite.BLL.BusinessModels;
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
            Product phone = Database.Products.Get(orderDto.PhoneId);

            // валидация
            if (phone == null)
                throw new ValidationException("Телефон не найден", "");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                PhoneId = phone.Id,
                Sum = sum,
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
