using System;

namespace ObjetoTransferencia
{
    public class Estoque
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DataModificacao { get; set; }  
    }
}
