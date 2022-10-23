using Akakce.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Services.Handlers.Classes;

namespace Service.Test
{
    public class Tests
    {
        private AddToCartHandler _handler;

        [SetUp]
        public void Setup()
        {
            InitTestDatabase();
        }

        [Test]
        [TestCase("7022b0b8-96ea-490c-94a7-3df0771c4efc", 3)]
        [TestCase("7022b0b8-96ea-490c-94a7-3df0771c4efc", 1)]
        [TestCase("f49fa83d-d685-4435-ba58-38c56947ca38", 6)]
        public void AddToCartHandlerHandle_WhenStockNotExist_ReturnUnSuccess(Guid productId, int count)
        {

            var result = _handler.Handle(new Services.Commands.Request.AddToCartRequest { ProductId = productId, ProductCount = count }, new CancellationToken()).Result;

            Assert.That(result.Status == Services.Common.Enum.ResultStatusEnum.UnSuccess);
        }



        [Test]
        [TestCase("f49fa83d-d685-4435-ba58-38c56947ca38", 2)]
        public void AddtoCartHandle_WhenStockExist_ReturnSuccess(Guid productId, int count)
        {
            var result = _handler.Handle(new Services.Commands.Request.AddToCartRequest { ProductId = productId, ProductCount = count }, new CancellationToken()).Result;

            Assert.That(result.Status == Services.Common.Enum.ResultStatusEnum.Success);
        }

        [Test]
        public void AddtoCartHandle_WhenErrorOccured_ReturnError()
        {
            var result = _handler.Handle(default, new CancellationToken()).Result;

            Assert.That(result.Status == Services.Common.Enum.ResultStatusEnum.Error);
        }

        /// <summary>
        /// Create InMemory Database And Preapare Dummy Data
        /// </summary>
        private void InitTestDatabase()
        {
            var productStocks = new List<ProductStock>
            {
                new ProductStock { ProductId = Guid.Parse("f49fa83d-d685-4435-ba58-38c56947ca38"), Stock = 5 },
                new ProductStock { ProductId = Guid.Parse("7022b0b8-96ea-490c-94a7-3df0771c4efc"), Stock = 0 }
            }.AsQueryable();

            var optionsBuilder = new DbContextOptionsBuilder<AkakceContext>().UseInMemoryDatabase("TestDatabase");
            var _dbContext = new AkakceContext(optionsBuilder.Options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.ProductStocks.AddRange(productStocks);
            _dbContext.SaveChanges();

            _handler = new AddToCartHandler(_dbContext);
        }
    }
}