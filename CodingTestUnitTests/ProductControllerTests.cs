using AutoMapper;
using CodingTest.Controllers;
using CodingTest.DataModel;
using CodingTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit;
using Microsoft.AspNetCore.Http;

namespace CodingTestUnitTests
{
    public class ProductsControllerTests
    {
        [Test]
        public void Get_Returns_OkResult()
        {
            var logger = new Mock<ILogger<ProductsController>>();
            var prodRepo = new Mock<IRepo<Product>>();
            var mapper = new Mock<IMapper>();
            prodRepo.Setup(repo => repo.GetAll()).Returns(new List<Product>());

            var controller = new ProductsController(logger.Object, prodRepo.Object, mapper.Object);

            var result = controller.Get();
            var okResult = result.Result as OkObjectResult;

            Assert.IsNotNull(okResult); 
            Assert.That(okResult.StatusCode, Is.EqualTo(200)); 
        }

        [Test]
        public void GetByColour_Returns_OkResult()
        {
            var logger = new Mock<ILogger<ProductsController>>();
            var prodRepo = new Mock<IRepo<Product>>();
            var mapper = new Mock<IMapper>();

            var controller = new ProductsController(logger.Object, prodRepo.Object, mapper.Object);

            var result = controller.Get();
            var okResult = result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetByColour_Returns_BadRequest_When_ExceptionThrown()
        {
            var logger = new Mock<ILogger<ProductsController>>();
            var prodRepo = new Mock<IRepo<Product>>();
            var mapper = new Mock<IMapper>();

            prodRepo.Setup(repo => repo.GetAll()).Throws(new Exception()); 

            var controller = new ProductsController(logger.Object, prodRepo.Object, mapper.Object);

            // Act
            var result = controller.Get("Red");
            var badResult = result.Result as BadRequestResult;
            // Act
            Assert.IsNotNull(badResult); 
            Assert.That(badResult.StatusCode, Is.EqualTo(400)); 
        }
    }
}