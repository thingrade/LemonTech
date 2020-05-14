using Lemontech.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LemonTech.Repository.Product.Interface
{
    public interface IProductService
    {
        Task<List<ProductResult>> GetProductList();
        Task<ProductResult> GetProductById(int productId);
        Task<ResponseModel> CreateProduct(Lemontech.DataLayer.Models.Product model);
        Task<ResponseModel> UpdateProduct(int id, Lemontech.DataLayer.Models.Product model);
        Task<ResponseModel> DeleteProduct(int id);
    }
}
