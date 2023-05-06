using Microsoft.EntityFrameworkCore;

namespace Shope.DAL;

public class CategoriesRepo : GenericRepo<Categories>, ICategoriesRepo
{
    private readonly ShopeContext _context;
    public CategoriesRepo(ShopeContext context) : base(context)
    {
        _context = context;
    }

    public List<Categories> GetCategoriesWithProducts()
    {
        return _context.categories.Include(p => p.Products).ToList();

    }

    public Categories GetCategoryWithProducts(Guid id)
    {
        return _context.categories.Include(p => p.Products).FirstOrDefault(c => c.Id == id);
    }
}
