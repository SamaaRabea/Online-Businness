using AutoMapper;
using Shope.DAL;

namespace Shope.BL;

public class ProductManager : IProductManager
{
    private readonly IProductRepo _productRepo;
    private readonly IMapper _mapper;

    public ProductManager(IProductRepo productRepo ,IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }
    public List<ProductDTO> GetAllProducts()
    {
        var dbProducts = _productRepo.GetAll();
        var dTOList = _mapper.Map<List<ProductDTO>>(dbProducts);
        return dTOList;

    }
    public ProductDTO? GetProductById(Guid id)
    {
        var dbProduct = _productRepo.GetById(id);
        if(dbProduct == null)
        {
            return null;
        }
        return _mapper.Map<ProductDTO>(dbProduct);
    }

    public ProductDTO AddProduct(ProductDTO productDto)
    {
        var dbProduct= _mapper.Map<Product>(productDto);
        dbProduct.Id=Guid.NewGuid();
        _productRepo.Add(dbProduct);
        _productRepo.SaveChanges();
        return _mapper.Map<ProductDTO>(dbProduct);
    }

    public void EditProduct(ProductDTO product)
    {
        var dbProduct =_productRepo.GetById(product.Id);
        _mapper.Map(product,dbProduct);
        _productRepo.Update(dbProduct);
        _productRepo.SaveChanges();
    }
    public void Delete(Guid id)
    {
        var dbProduct = _productRepo.GetById(id);
        _productRepo.Delete(dbProduct);
        _productRepo.SaveChanges();

    }

    

    

   
}

