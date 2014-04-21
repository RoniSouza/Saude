using System;

namespace ObjetoTransferencia
{
    public class Profissional : Pessoa
    {
        public string Cargo { get; set; }
        public string ConselhoClasse { get; set; }
        public string NumeroRegistro { get; set; }
        public string UFRegistro { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
