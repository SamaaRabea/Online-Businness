namespace Shope.BL;

public interface ICategoriesManagers
{
    public List<CategoriesDTO> GetAllCategories();

    CategoriesDTO? GetCategoryById(Guid id);
    CategoriesDTO AddCategory(CategoriesDTO categories);
    void EditCategory(CategoriesDTO categories);
    void Delete(Guid id);
}

