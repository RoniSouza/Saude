using System;

namespace ObjetoTransferencia
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public decimal Preco { get; set; }
        public string Lote { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DataModificacao { get; set; }   
    
    }
}
