using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjetoTransferencia
{
    public class PrescricaoMedica
    {
        public int IdPrescricaoMedica { get; set; }
        public int IdPessoa { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Horario { get; set; }
        public int QtdDias { get; set; }
        public Boolean TarefaRealizada { get; set; }
        public DateTime DataCadastro { get; set; }
        public string HoraRealizacaoTarefa { get; set; }
        public string NomeMedico { get; set; }
        public string NomeEnfermeiro { get; set; }
        public DateTime DataModificacao { get; set; }
          
    }
}
