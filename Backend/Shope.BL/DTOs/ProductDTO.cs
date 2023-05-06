namespace Shope.BL;
public class ProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public float Price { get; set; }
    public string Discription { get; set; } = "";
    public string type { get; set; } = "";
    public Guid CategoryId { get; set; }

}

