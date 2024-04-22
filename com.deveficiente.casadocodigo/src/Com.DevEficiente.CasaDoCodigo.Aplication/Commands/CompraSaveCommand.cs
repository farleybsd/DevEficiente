using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor.Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class CompraSaveCommand : IRequest<CompraResult>
    {
        public string Email { get; set; }

        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string documento { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string cidade { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string telefone { get; set; }
        public string cep { get; set; }
        public CompraSaveCommand(string nome, string sobrenome, string documento, string endereco, string complemento, string cidade, string pais, string estado, string telefone, string cep,string email)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome), "O nome não pode ser nulo");
            this.sobrenome = sobrenome ?? throw new ArgumentNullException(nameof(sobrenome), "O sobrenome não pode ser nulo");
            this.documento = documento ?? throw new ArgumentNullException(nameof(documento), "O documento não pode ser nulo");
            this.endereco = endereco ?? throw new ArgumentNullException(nameof(endereco), "O endereco não pode ser nulo");
            this.complemento = complemento ?? throw new ArgumentNullException(nameof(complemento), "O complemento não pode ser nulo");
            this.cidade = cidade ?? throw new ArgumentNullException(nameof(cidade), "O cidade não pode ser nulo");
            this.pais = pais ?? throw new ArgumentNullException(nameof(pais), "O pais não pode ser nulo");
            this.estado = estado ?? throw new ArgumentNullException(nameof(estado), "O estado não pode ser nulo");
            this.telefone = telefone ?? throw new ArgumentNullException(nameof(telefone), "O telefone não pode ser nulo");
            this.cep = cep ?? throw new ArgumentNullException(nameof(cep), "O cep não pode ser nulo");
            this.Email = email;
        }

        public Compra CommandToEntity(CompraSaveCommand compraSaveCommand)
        {
            return new Compra(new Email(compraSaveCommand.Email),
                              new Pessoa(compraSaveCommand.nome, compraSaveCommand.sobrenome),
                             new DocumentoCompra(compraSaveCommand.documento).CriarDocumento(),
                              new Localizacao(compraSaveCommand.endereco,
                                              compraSaveCommand.complemento,
                                              compraSaveCommand.cidade,
                                              compraSaveCommand.cep),
                              new Pais(compraSaveCommand.pais),
                              new Estado(compraSaveCommand.pais, compraSaveCommand.estado),
                              new Telefone(compraSaveCommand.telefone));
        }
    }
}