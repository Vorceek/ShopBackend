using System.ComponentModel.DataAnnotations;

namespace ShopBackend.DTOs.Produto {
    public class ProductCreateDto {

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(150)]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public string? Barcode { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; } = default!;

    }
}
