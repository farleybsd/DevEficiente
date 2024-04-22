using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor.Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Compra
    {
        public Compra(Email email, Pessoa pessoa, DocumentoCompra documentoCompra, Localizacao localizacao, Pais pais, Estado estado, Telefone telefone)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email), "O email não pode ser nulo");
            Pessoa = pessoa ?? throw new ArgumentNullException(nameof(pessoa), "A pessoa não pode ser nula");
            DocumentoCompra = documentoCompra ?? throw new ArgumentNullException(nameof(documentoCompra), "O documento da compra não pode ser nulo");
            Localizacao = localizacao ?? throw new ArgumentNullException(nameof(localizacao), "A localização não pode ser nula");
            Pais = pais ?? throw new ArgumentNullException(nameof(pais), "O país não pode ser nulo");
            Estado = estado ?? throw new ArgumentNullException(nameof(estado), "O estado não pode ser nulo");
            Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone), "O telefone não pode ser nulo");
        }
        public Compra()
        {
            
        }

        public Email Email { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public DocumentoCompra DocumentoCompra { get; private set; }
        public Localizacao Localizacao { get; private set; }
        public Pais Pais { get; private set; }
        public Estado Estado { get; private set; }
        public Telefone Telefone { get; set; }

        public void DefinirDocumentoCompra(DocumentoCompra documentoCompra)
        {
            DocumentoCompra = documentoCompra;
        }
        public void DefinirEmailCompra(Email email)
        {
            Email = email;
        }

        public void DefinirEstadoCompra(Estado estado)
        {
            Estado = estado;
        }

        public void DefinirLocalizacaoCompra(Localizacao localizacao)
        {
            Localizacao = localizacao;
        }
        public void DefinirPaisCompra(Pais pais)
        {
            Pais = pais;
        }
        public void DefinirPessoaCompra(Pessoa pessoa)
        {
            Pessoa = pessoa;
        }

        public void DefinirTelefoneCompra(Telefone telefone)
        {
            Telefone = telefone;
        }
    }
}
