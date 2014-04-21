using System;

namespace ObjetoTransferencia
{
   public class ConsultaMedica
    {

        public int IdConsulta { get; set; }
        public string NomeMedico { get; set; }
        public string NomePaciente { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string TipoConsulta { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DataModificacao { get; set; }   
   }
}
