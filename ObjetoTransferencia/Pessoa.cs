using System;

namespace ObjetoTransferencia
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string RG { get; set; }
        public string OrgaoEmissor { get; set; }
        public string UF { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public string CPF { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime DataModificacao { get; set; }   
    }
}
