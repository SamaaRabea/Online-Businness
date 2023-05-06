namespace Shope.DAL;

public interface ICategoriesRepo :IGenericRepo<Categories>
{
    List<Categories> GetCategoriesWithProducts();
    Categories GetCategoryWithProducts(Guid id);
}
