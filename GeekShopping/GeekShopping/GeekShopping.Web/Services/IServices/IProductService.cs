using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices {
    public interface IProductService {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> FindProductById(long id);
        Task<ProductModel> Create(ProductModel productModel);
        Task<ProductModel> Update(ProductModel productModel);
        Task<bool> Delete(long id);
    }
}
