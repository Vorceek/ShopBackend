using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBackend.Models {
    public class ProdutoModel {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; set; } = default!;

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O Preço do produto é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade de um produto é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade de um produto não pode ser negativa.")]
        public int QuantidadeEstoque { get; set; }

        public string? CodigoDeBarras { get; set; }

        [Required(ErrorMessage = "A marca do produto é obrigatório.")]
        public string Marca { get; set; } = default!;

        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeModificacao { get; set; }
    }
}
