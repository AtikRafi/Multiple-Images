
namespace Multiple_Images.Models.dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = null!;
        public List<ProductImageDto> Images { get; set; } = new();
        public List<VariantCreateDto> Variants { get; set; } = new();
    }

    public class ProductImageDto
    {
        public IFormFile File { get; set; } = null!;
        public int DisplayOrder { get; set; }
    }

    public class VariantCreateDto
    {
        public string Name { get; set; } = null!;
        public List<VariantImageDto> Images { get; set; } = new();
    }

    public class VariantImageDto
    {
        public IFormFile File { get; set; } = null!;
        public int DisplayOrder { get; set; }
    }

}
