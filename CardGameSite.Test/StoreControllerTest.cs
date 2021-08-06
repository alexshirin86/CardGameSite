using NUnit.Framework;
using CardGameSite.WEB.Controllers;
using CardGameSite.DAL.Entities;
using CardGameSite.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;



namespace CardGameSite.Test
{
    public class StoreControllerTest
    {
        private StoreController _storeController;
        private ViewResult _viewResult;

        [SetUp]
        public void Setup()
        {
            //_storeController = new StoreController(new FakeRepository());
            _storeController.PageSize = 3;
            _viewResult = _storeController.Store(null, 2) as ViewResult;
        }

        [Test]
        public void StoreTest_ViewResult()
        {
            //Action
            CardGameSite.WEB.Models.ProductsList result = _viewResult.ViewData.Model as CardGameSite.WEB.Models.ProductsList;

            //Arrange
            CardGameSite.WEB.Models.Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);

            Assert.True("P4" == prodArray[0].Name);
            Assert.AreEqual("P5", prodArray[1].Name);
        }
    }
    public class FakeRepository : IRepository<Product>
    {
        private List<Product> _products;
        private List<CategoryProduct> _categoriesProducts;

        public FakeRepository()
        {
            _categoriesProducts = new List<CategoryProduct>
            {
                new CategoryProduct { Id = 1, Name = "��������� 1" },
                new CategoryProduct { Id = 2, Name = "��������� 2" },
                new CategoryProduct { Id = 3, Name = "��������� 3" },
                new CategoryProduct { Id = 4, Name = "��������� 4" },
                new CategoryProduct { Id = 5, Name = "��������� 5" },
                new CategoryProduct { Id = 6, Name = "��������� 6" },
                new CategoryProduct { Id = 7, Name = "��������� 7" },
            };

            _products = new List<Product>
            {
                new Product { Id = 1, Name = "����� 1", Description = "�������� 1", Price = 3.99M, CategoriesProduct = new List<CategoryProduct>{ _categoriesProducts[1] }},
                new Product { Id = 2, Name = "����� 2", Description = "�������� 2", Price = 5.99M, CategoriesProduct = new List<CategoryProduct>{ _categoriesProducts[1] }},
                new Product { Id = 3, Name = "����� 3", Description = "�������� 3", Price = 7.99M, CategoriesProduct = new List<CategoryProduct>{ _categoriesProducts[2] }},
                new Product { Id = 4, Name = "����� 4", Description = "�������� 4", Price = 2.99M, CategoriesProduct = new List<CategoryProduct>{ _categoriesProducts[2] }},
                new Product { Id = 5, Name = "����� 5", Description = "�������� 5", Price = 0.99M, CategoriesProduct = new List<CategoryProduct>{ _categoriesProducts[2] }},
                new Product { Id = 6, Name = "����� 6", Description = "�������� 6", Price = 1.99M, CategoriesProduct = new List<CategoryProduct>{ _categoriesProducts[3] }},
                new Product { Id = 7, Name = "����� 7", Description = "�������� 7", Price = 3.99M, CategoriesProduct = new List<CategoryProduct>{ _categoriesProducts[3] }},
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product Get(int id)
        {
            return (Product)_products.Where(p => p.Id == id);
        }

        public void Create(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            _products[_products.ToList().FindIndex(p => p.Id == product.Id)] = product;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return _products.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            _products.Remove(_products.Find(p => p.Id == id));
        }
    }
}