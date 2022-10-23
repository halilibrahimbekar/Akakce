using Akakce.Data;
using Data.Entities;
using MediatR;
using Service.Services.Commands.Request;
using Service.Services.Commands.Response;

namespace Service.Services.Handlers.Classes
{
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, AddToCartResponse>
    {
        private readonly AkakceContext _context;

        public AddToCartHandler(AkakceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Stok Kontrolü Sonrası Sepete Ekleme İşlemini Yapar
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AddToCartResponse> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Check Stock
                if (!_context.ProductStocks.Any(x => x.ProductId == request.ProductId && x.Stock >= request.ProductCount))
                {
                    return Task.FromResult(new AddToCartResponse { Message = "Ürün Stoğu Yeterli Değil", Status = Common.Enum.ResultStatusEnum.UnSuccess });
                }


                var id = Guid.NewGuid();
                var cartItem = new CustomerCart
                {
                    Id = id,
                    ProductId = request.ProductId,
                    Count = request.ProductCount,
                    CustomerId = request.CustomerId,
                    CreatedDateTime = DateTime.Now
                };

                _context.CustomerCarts.Add(cartItem);
                _context.SaveChanges();

                return Task.FromResult(new AddToCartResponse { Message = "Ürün Sepetinize Eklendi", Status = Common.Enum.ResultStatusEnum.Success });
            }
            catch (Exception ex)
            {
                // error handling... 

                return Task.FromResult(new AddToCartResponse
                {
                    Message = "İşlem Yapılırken Hata Oluştu!",
                    Status = Common.Enum.ResultStatusEnum.Error
                });
            }
        }
    }
}
