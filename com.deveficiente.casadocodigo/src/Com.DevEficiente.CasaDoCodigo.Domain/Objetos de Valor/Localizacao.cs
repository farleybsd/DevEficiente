namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class Localizacao
    {
        public string Endereco { get; }
        public string Complemento { get; }
        public string Cidade { get; }
        public string Cep { get; }

        public Localizacao(string endereco, string complemento, string cidade, string cep)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("O endereço não pode ser nulo, vazio ou conter apenas espaços em branco", nameof(endereco));

            Endereco = endereco;

            Complemento = string.IsNullOrWhiteSpace(complemento) ? "Sem Complemento" : complemento;

            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException("A cidade não pode ser nula, vazia ou conter apenas espaços em branco", nameof(cidade));

            Cidade = cidade;

            if (string.IsNullOrWhiteSpace(cep))
                throw new ArgumentException("O CEP não pode ser nulo, vazio ou conter apenas espaços em branco", nameof(cep));

            Cep = cep;
        }
    }
}