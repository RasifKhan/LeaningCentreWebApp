

using DataAccess.Model;
using DtoModel;

namespace LearningCentreClientApp.Service.IService
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryById(int id);
        Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO);
        Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO);
        Task<bool> DeleteCategory(int id);

    }
}
