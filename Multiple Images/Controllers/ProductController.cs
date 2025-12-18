using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multiple_Images.Models;
using Multiple_Images.Models.dtos;

namespace Multiple_Images.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment env;
        public ProductController(AppDbContext _db, IWebHostEnvironment env)
        {
            db = _db;
            this.env = env;
        }
        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> Create([FromForm] ProductDto dto)
        //{
        //    var product = new Product
        //    {
        //        Name = dto.Name
        //    };
        //    var file = Path.Combine(env.WebRootPath,"Uploads", "products");
        //    if (!Directory.Exists(file))
        //    {
        //        Directory.CreateDirectory(file);
        //    }

        //    foreach (var formFile in dto.ImageUrls)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);

        //            var filePath = Path.Combine(file, fileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //            product.Images.Add(new Image
        //            {
        //                Url = "/Uploads/products/" + fileName
        //            });
        //        }
        //    }
        //    db.Products.Add(product);
        //    await db.SaveChangesAsync()                                     ;
        //    return Ok(product);

        //}
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> create([FromForm] ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,

            };
           foreach(var i in dto.Images)
            {
             var url =  await SaveFileAsync(i.File, "Producttttt");
                product.Images.Add(new Image
                {
                    displayOrder = i.DisplayOrder,
                    Url = url
                });
            }

           foreach(var i in dto.Variants)
            {
                var variant = new Variant { Name = i.Name, };
                foreach(var f in i.Images)
                {
                    var url = await SaveFileAsync(f.File, "variant");
                    variant.VariantImages.Add(new VariantImage
                    {
                        Url = url,
                        displayOrder = f.DisplayOrder,
                    });
                }
                product.variants.Add(variant);
            }
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        private async Task<string> SaveFileAsync(IFormFile file, string className)
        {
            if (env.WebRootPath == null)
                throw new Exception("wwwroot not found.");

            // Create folder based on class name
            var folderPath = Path.Combine(env.WebRootPath, "uploads", className);
            Directory.CreateDirectory(folderPath);

            // Generate unique file name
            var fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(folderPath, fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative URL
            return $"/uploads/{className}/{fileName}";
        }

    }
}
