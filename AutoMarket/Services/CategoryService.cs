using AutoMapper;
using AutoMarket.DTOs.Category;
using AutoMarket.Web.DTOs.Category;
using AutoMarket.Web.Entities;
using AutoMarket.Web.Repositories;
using AutoMarket.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Categories.AddAsync(categoryEntity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}