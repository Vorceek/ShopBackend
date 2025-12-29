namespace ShopBackend.DTOs.Produto {
    public class ProdutoPatchDto {

        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? QuantidadeEstoque { get; set; }

    }
}
