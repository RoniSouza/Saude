using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjetoTransferencia
{
    public class EvolucaoEnfermagemClass
    {
        public int IdPessoa { get; set; }
        public string FrequenciaCardiaca { get; set; }
        public string PressaoArterial { get; set; }
        public string Respiracao { get; set; }
        public string Temperatura { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DataModificacao { get; set; }   
    }
}
