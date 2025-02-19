using AutoMapper;
using BusinessLogic.Repository.IRepository;
using DataAccess.Model;
using DtoModel;
using Microsoft.AspNetCore.Mvc;
namespace LearningCentreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(_mapper.Map<List<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryRepository.Get(id);
            if (category == null) return NotFound();
            return Ok(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var result = await _categoryRepository.Create(categoryDTO);
            return Ok(_mapper.Map<CategoryDTO>(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> Update(int id, CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id) return BadRequest();
            var category = _mapper.Map<Category>(categoryDTO);
            var result = await _categoryRepository.Update(categoryDTO);
            return Ok(_mapper.Map<CategoryDTO>(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryRepository.Delete(id);
            return NoContent();
        }
    }
}
