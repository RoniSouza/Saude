using System;
using System.Collections.Generic;

namespace ObjetoTransferencia
{
    public class Paciente : Pessoa
    {
        public string Convenio { get; set; }
        public string NumeroInscricao { get; set; }
        public string ValidadeCartao { get; set; }
        public string TipoPlano { get; set; }
        public string Responsavel { get; set; }
        public string RGResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public string CorRaca { get; set; }
        public string Sexo { get; set; }
        public byte[] QRCode { get; set; }
        public string Leito { get; set; }

    }
}
