using MediatR;
using Service.Services.Commands.Response;

namespace Service.Services.Commands.Request
{
    /// <summary>
    /// Sepete Ekleme Methodu Request'i
    /// </summary>
    public class AddToCartRequest : IRequest<AddToCartResponse>
    {
        /// <summary>
        /// Eklenecek Ürün Id'si
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Müşteri Id'si
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Eklenecek Ürün Adeti
        /// </summary>
        public int ProductCount { get; set; }
    }
}
