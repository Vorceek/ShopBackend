using System.ComponentModel.DataAnnotations;

namespace ShopBackend.DTOs.Produto {
    public class ProdutoPutDto {

        [Required]
        [StringLength(150)]
        public string Nome { get; set; } = default!;

        public string? Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int QuantidadeEstoque { get; set; }

        [Required]
        public string Marca { get; set; } = default!;

    }
}
