namespace Shope.BL;

public interface IProductManager 
{
    public List<ProductDTO> GetAllProducts();
    ProductDTO? GetProductById(Guid id);
    ProductDTO AddProduct(ProductDTO product);
    void EditProduct(ProductDTO product);
    void Delete(Guid id);
}

