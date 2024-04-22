using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor.Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Builders
{
    public class ConstrutorCompra : IConstrutorCompraBuilder
    {
        private Compra _compra = new Compra();
        public void ConstruirDocumentoCompra(string documento)
        {
            DocumentoCompra documentoCompra = new DocumentoCompra(documento);
            _compra.DefinirDocumentoCompra(documentoCompra);
        }

        public void ConstruirEmail(string email)
        {
            Email setEmail = new Email(email);
            _compra.DefinirEmailCompra(setEmail);
        }

        public void ConstruirEstado(string idPais, string nomeEstado)
        {
            Estado estado = new Estado(idPais, nomeEstado);
            _compra.DefinirEstadoCompra(estado);
        }

        public void ConstruirLocalizacao(string endereco, string complemento, string cidade, string cep)
        {
            Localizacao localizacao = new Localizacao(endereco, complemento, cidade, cep);
            _compra.DefinirLocalizacaoCompra(localizacao);
        }

        public void ConstruirPais(string nome)
        {
            Pais pais = new Pais(nome);
            _compra.DefinirPaisCompra(pais);
        }

        public void ConstruirPessoa(string nome, string sobrenome)
        {
            Pessoa pessoa = new Pessoa(nome, sobrenome);
            _compra.DefinirPessoaCompra(pessoa);
        }

        public void ConstruirTelefone(string numero_Telefone)
        {
            Telefone telefone = new Telefone(numero_Telefone);
            _compra.DefinirTelefoneCompra(telefone);
        }

        public Compra ObterCompra()
        {
            return _compra;
        }
    }
}
