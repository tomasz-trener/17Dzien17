using P05Sklep.Shared;

namespace P07Blazor.Client.Services.ProductService
{
    public interface IProductService
    {
        Product[] Products { get; set; }
        Task GetProducts();

        Task SearchProducts(string text, int page, int pageSize);
    }
}
