namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class Pessoa
    {
        public string _Nome { get; private set; }
        public string _Sobrenome { get; private set; }
        public Pessoa(string nome, string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser nulo, vazio ou conter apenas espaços em branco", nameof(nome));
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException("O sobrenome não pode ser nulo, vazio ou conter apenas espaços em branco", nameof(sobrenome));

            _Nome = nome;
            _Sobrenome = sobrenome;
        }
    }
}
