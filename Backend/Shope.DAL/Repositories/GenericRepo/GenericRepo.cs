namespace Shope.DAL;
public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly ShopeContext _context;

    public GenericRepo(ShopeContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        // _context.Products === _context.set<Product>();
        return _context.Set<T>().ToList();
    }

    public T? GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);  
    }

    public void Update(T entity)
    {
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}

