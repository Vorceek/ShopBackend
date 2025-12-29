using System.ComponentModel.DataAnnotations;

namespace ShopBackend.DTOs.Produto {
    public class ProductPutDto {

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Required]
        public string Brand { get; set; } = default!;

    }
}
