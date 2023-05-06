using Shope.DAL;

namespace Shope.BL;

public class CategoriesDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public virtual ICollection<ProductDTO> Products { get; set; } = new HashSet<ProductDTO>();

}

