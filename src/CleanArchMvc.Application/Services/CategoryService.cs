using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);

        await _categoryRepository.CreateAsync(categoryEntity);
    }

    public async Task<CategoryDTO?> GetById(int? id)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id);
        if (categoryEntity is null)
            return null;

        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesAsync();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task Remove(int? id)
    {
        // no final do código abaixo poderia ter o .Result ao invés do await
        var categoryEntity = await _categoryRepository.GetByIdAsync(id);
        await _categoryRepository.DeleteAsync(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);

        await _categoryRepository.UpdateAsync(categoryEntity);
    }
}
