
using System.ComponentModel.DataAnnotations.Schema;

namespace Multiple_Images.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } =null!;
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Variant> variants { get; set; } = new List<Variant>();
    }
    public class Image
    {
        public int Id { get; set; }
        public int displayOrder { get; set; }

        public string Url { get; set; } = null!;
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
    public class Variant
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public ICollection<VariantImage> VariantImages { get; set; } = new List<VariantImage>();
    }

    public class VariantImage
    {
        public int Id { get; set; }
        public int displayOrder { get; set; }
        public string Url { get; set; } = null!;
        public int VariantId { get; set; }
        public Variant? Variant { get; set; }
    }

}
