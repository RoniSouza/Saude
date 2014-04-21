using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjetoTransferencia
{
    public class EvolucaoMedicaClass
    {
        public int IdPessoa { get; set; }
        public string EvolucaoMedica { get; set; }
        public string  Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DataModificacao { get; set; }   
    }
}
