namespace Shope.DAL;

public class ProductRepo : GenericRepo<Product>, IProductRepo
{
    public ProductRepo(ShopeContext context) : base(context)
    {
    }
}
