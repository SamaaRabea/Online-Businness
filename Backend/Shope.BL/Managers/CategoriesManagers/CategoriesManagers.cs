using AutoMapper;
using Shope.DAL;

namespace Shope.BL;

public class CategoriesManagers : ICategoriesManagers
{
    private IMapper _mapper;
    private ICategoriesRepo _categoriesRepo;

    public CategoriesManagers(ICategoriesRepo categoriesRepo, IMapper mapper)
    {
        _mapper = mapper;
        _categoriesRepo = categoriesRepo;
    }
    public List<CategoriesDTO> GetAllCategories()
    {
        var dbCategories = _categoriesRepo.GetCategoriesWithProducts();
        var dTOList = _mapper.Map<List<CategoriesDTO>>(dbCategories);
        return dTOList;
    }

    public CategoriesDTO? GetCategoryById(Guid id)
    {
        var dbCategories = _categoriesRepo.GetCategoryWithProducts(id);
        if (dbCategories == null)
        {
            return null;
        }
        return _mapper.Map<CategoriesDTO>(dbCategories);
    }
    public CategoriesDTO AddCategory(CategoriesDTO categoriesDto)
    {
        var dbCategories = _mapper.Map<Categories>(categoriesDto);
        dbCategories.Id = Guid.NewGuid();
        _categoriesRepo.Add(dbCategories);
        _categoriesRepo.SaveChanges();
        return _mapper.Map<CategoriesDTO>(dbCategories);
    }

    public void Delete(Guid id)
    {
        var dbCategories = _categoriesRepo.GetById(id);
        _categoriesRepo.Delete(dbCategories);
        _categoriesRepo.SaveChanges();
    }

    public void EditCategory(CategoriesDTO category)
    {
        var dbCategories = _categoriesRepo.GetById(category.Id);
        _mapper.Map(category, dbCategories);
        _categoriesRepo.Update(dbCategories);
        _categoriesRepo.SaveChanges();
    }

   
}

