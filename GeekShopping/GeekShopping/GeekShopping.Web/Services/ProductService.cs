using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Data;

namespace GeekShopping.Web.Services {
    public class ProductService :IProductService {

        private readonly HttpClient _httpClient;
        public const string BasePath = "/api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient) );
        }

        public async Task<ProductModel> Create(ProductModel productModel) {
            var response = await _httpClient.PostAsJson(BasePath,productModel);
            if(response.IsSuccessStatusCode)
                return await response.ReadContentAsync<ProductModel>();
            else
                throw new Exception("Alguma coisa de errado quando chamada a API");
        }

        public async Task<bool> Delete(long id) {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if(response.IsSuccessStatusCode)
                return true;
            else
                throw new Exception("Alguma coisa de errado quando chamada a API");
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts() {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id) {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> Update(ProductModel productModel) {
            var response = await _httpClient.PutAsJson(BasePath, productModel);
            if(response.IsSuccessStatusCode)
                return await response.ReadContentAsync<ProductModel>();
            else
                throw new Exception("Alguma coisa de errado quando chamad a API");
        }
    }
}
