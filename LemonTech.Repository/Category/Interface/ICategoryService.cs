using Lemontech.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LemonTech.Repository.Category.Interface
{
    public interface ICategoryService
    {
        Task<List<Lemontech.DataLayer.Models.Category>> GetCategoryList();
        Task<Lemontech.DataLayer.Models.Category> GetCategoryById(int id);
        Task<ResponseModel> CreateCategory(Lemontech.DataLayer.Models.Category model);
        Task<ResponseModel> UpdateCategory(int id, Lemontech.DataLayer.Models.Category model);
        Task<ResponseModel> DeleteCategory(int id);
    }
}
