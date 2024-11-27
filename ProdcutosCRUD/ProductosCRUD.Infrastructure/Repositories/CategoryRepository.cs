using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProdcutosCRUD.Common.Request;
using ProdcutosCRUD.Domain.Entities;
using ProdcutosCRUD.Persistence;
using ProductoCRUD.Common.Dtos;
using ProductosCRUD.Infrastructure.Interfaces;


namespace ProductosCRUD.Infrastructure.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ProductoCrudDbContext _context;
        private readonly IMapper _categoryMapper;
        public CategoryRepository(ProductoCrudDbContext context, IMapper categoryMapper)
        {
            _context = context;
            _categoryMapper = categoryMapper;
        }

        public async Task<List<CategoryDto>> GetCategories() {
            var categoriesDto = new List<CategoryDto>();
            var categoriesDb = await _context.Categories.Where(e => e.IsDeleted == false).ToListAsync();

            foreach (var category in categoriesDb)
            {
                categoriesDto.Add(_categoryMapper.Map<CategoryDto>(category));
            }

            return categoriesDto;
        }

        public async Task CreateNewCategory(CreateCategoryRequest request)
        {
            var category = new Category();

            category.Name = request.Name;

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(CategoryDto categoryDto, EditCategoryRequest request)
        {
            var category = _categoryMapper.Map<Category>(categoryDto);

            category.Name = request.Name;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(CategoryDto categoryDto)
        {
            var categoryDelete = _categoryMapper.Map<Category>(categoryDto);
            categoryDelete.IsDeleted = true;

            _context.Categories.Update(categoryDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var category =  await _context.Categories.FirstAsync(e => e.Id == id);

            var categoryDto = _categoryMapper.Map<CategoryDto>(category);

            return categoryDto;
        }

    }
}
