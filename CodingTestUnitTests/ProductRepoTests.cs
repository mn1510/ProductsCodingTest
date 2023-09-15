using NUnit.Framework;
using CodingTest.DataModel;
using CodingTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTestUnitTests
{
    [TestFixture]
    public class ProductsRepoTests
    {
        [Test]
        public void GetAll_Returns_AllProducts()
        {
            var repo = new ProductsRepo();

            var products = repo.GetAll();

            Assert.IsNotNull(products);
            Assert.That(products.Count(), Is.EqualTo(5)); 
        }

        [Test]
        public void GetEntity_Returns_ProductById()
        {
            var repo = new ProductsRepo();
            var productIdToFind = 1; 

            var product = repo.GetEntity(productIdToFind);

            Assert.IsNotNull(product);
            Assert.That(product.Id, Is.EqualTo(productIdToFind));
        }

        [Test]
        public void GetEntity_Returns_NullForNonexistentId()
        {
            var repo = new ProductsRepo();
            var nonexistentId = 100; 

            var product = repo.GetEntity(nonexistentId);

            Assert.IsNull(product);
        }

        [Test]
        public void GenerateRandomProducts_Returns_ListWithSpecifiedCount()
        {
            var repo = new ProductsRepo();
            var count = 10;

            var products = repo.GenerateRandomProducts(count);

            Assert.IsNotNull(products);
            Assert.That(products.Count, Is.EqualTo(count));
        }

        [Test]
        public void GenerateRandomProducts_Returns_UniqueProducts()
        {
            var repo = new ProductsRepo();
            var count = 10;

            var products = repo.GenerateRandomProducts(count);

            Assert.IsNotNull(products);
            Assert.That(products.DistinctBy(p => p.Id).Count(), Is.EqualTo(count)); 
        }
    }
}