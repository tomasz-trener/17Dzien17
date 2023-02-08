using P05Sklep.Shared;
using System.Net.Http.Json;

namespace P07Blazor.Client.Services.ProductService
{
    public class ProductService : IProductService
    {

        private HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Product[] Products { get; set; }
        
        public async Task GetProducts()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceReponse<Product[]>>("api/product");

            Products = result.Data;
        }

        public async Task SearchProducts(string text, int page=1, int pageSize=5)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceReponse<Product[]>>($"api/product/search/{text}/{page}/{pageSize}");

            Products = result.Data;
        }
    }
}
