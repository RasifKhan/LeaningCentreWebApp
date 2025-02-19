using DataAccess.Model;
using DtoModel;
using LearningCentreClientApp.Service.IService;
using System.Net.Http.Json;

namespace LearningCentreClientApp.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public CategoryService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryDTO>>($"{_baseUrl}/api/Categories");
        }
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryDTO>($"{_baseUrl}/api/Categories/{id}");
        }
        public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Categories", categoryDTO);
            return await response.Content.ReadFromJsonAsync<CategoryDTO>();
        }
        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Categories/{categoryDTO.Id}", categoryDTO);
            return await response.Content.ReadFromJsonAsync<CategoryDTO>();
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Categories/{id}");
            return response.IsSuccessStatusCode;
        }



    }
}
