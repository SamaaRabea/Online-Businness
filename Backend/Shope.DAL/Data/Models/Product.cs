using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shope.DAL;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public float Price { get; set; }
    public string Discription { get; set; } = "";
    public string type { get; set; } = "";

    [ForeignKey("Categories")]
    public Guid CategoryId { get; set; }
    public Categories? Categories { get; set; }


}

