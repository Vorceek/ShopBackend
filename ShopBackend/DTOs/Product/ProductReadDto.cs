namespace ShopBackend.DTOs.Produto {
    public class ProductReadDto {

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Barcode { get; set; }
        public string Brand { get; set; } = default!;

    }
}
