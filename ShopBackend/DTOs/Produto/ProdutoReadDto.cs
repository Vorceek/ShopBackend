namespace ShopBackend.DTOs.Produto {
    public class ProdutoReadDto {

        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string? CodigoDeBarras { get; set; }
        public string Marca { get; set; } = default!;

    }
}
