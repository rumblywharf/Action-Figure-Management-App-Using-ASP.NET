using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_1.Controllers;
using Assignment_1.Data;
using Assignment_1.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace VirtualCollectionz_Test
{
    [TestClass]
    public class ProductsControllerTest
    {
        private ApplicationDbContext _context;

        List<Product> products = new List<Product>();

        ProductsController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            var buyer = new Buyer { Id = 100, Email = "test123@test.com", Name = "Test Buyer", Phone = 1234567890 };
            _context.Buyers.Add(buyer);
            _context.SaveChanges();

            products.Add(new Product { Id = 101, Name = "Product 1", Paid = 11, Buyer = buyer });
            products.Add(new Product { Id = 102, Name = "Product 2", Paid = 12, Buyer = buyer });
            products.Add(new Product { Id = 103, Name = "Product 3", Paid = 13, Buyer = buyer });

            foreach(var p in products)
            {
                _context.Products.Add(p);
            }

            _context.SaveChanges();

            controller = new ProductsController(_context);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;
            Assert.AreEqual("Index", viewResult.ViewName);
        }

        [TestMethod]
        public void CreateViewLoads()
        {
            var result = controller.Create();
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Create", viewResult.ViewName);
        }

        [TestMethod]
        public void CreateIsNotNull()
        {
            var result = controller.Create();
            var viewData = controller.ViewData["Id"];
            Assert.IsNotNull(viewData);
        }

        [TestMethod]
        public void CreateReturnsView()
        {
            var product = new Product { Id = 200, Name = "Product Name", Paid = 15, Buyer = new Buyer { Id = 300, Name = "Buyer Name" } };
            var result = controller.Create(product);
            var redirect = (RedirectToActionResult)result.Result;
            Assert.AreEqual("Index", redirect.ActionName);
        }

        [TestMethod]
        public void CreateToDB()
        {
            var product = new Product { Id = 400, Name = "New Product Name", Paid = 16, Buyer = new Buyer { Id = 500, Name = "New Buyer Name" } };
            _context.Products.Add(product);
            _context.SaveChanges();
            Assert.AreEqual(product, _context.Products.ToArray()[3]);
        }


    }
}
