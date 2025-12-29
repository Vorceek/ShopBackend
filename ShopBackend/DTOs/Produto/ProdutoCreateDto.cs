using System.ComponentModel.DataAnnotations;

namespace ShopBackend.DTOs.Produto {
    public class ProdutoCreateDto {

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; set; } = default!;

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        public decimal Preco { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int QuantidadeEstoque { get; set; }

        public string? CodigoDeBarras { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória.")]
        public string Marca { get; set; } = default!;

    }
}
