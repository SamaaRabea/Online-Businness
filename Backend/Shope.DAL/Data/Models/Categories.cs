using System.ComponentModel.DataAnnotations;

namespace Shope.DAL;

public class Categories
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
} 

