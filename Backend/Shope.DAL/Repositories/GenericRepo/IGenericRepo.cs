namespace Shope.DAL;

public interface IGenericRepo<T> where T : class
{
    List<T> GetAll();
    T? GetById(Guid id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void SaveChanges();
}
