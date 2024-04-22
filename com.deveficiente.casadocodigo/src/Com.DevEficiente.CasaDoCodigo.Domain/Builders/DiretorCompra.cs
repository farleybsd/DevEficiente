using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor.Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Builders
{
    public class DiretorCompra
    {
        private IConstrutorCompraBuilder _construtorCompraBuilder;

        public DiretorCompra(IConstrutorCompraBuilder construtorCompraBuilder)
        {
            _construtorCompraBuilder = construtorCompraBuilder;
        }

        public void ConstruirCompra(string email, string nome, string sobrenome, string documentoCompra, string endereco, string complemento, string cidade, string cep, string idPais, string nomeEstado, string telefone)
        {
            _construtorCompraBuilder.ConstruirDocumentoCompra(documentoCompra);
             _construtorCompraBuilder.ConstruirEmail(email);
            _construtorCompraBuilder.ConstruirEstado(idPais, nomeEstado);
            _construtorCompraBuilder.ConstruirLocalizacao(endereco, complemento, cidade, cep);
            _construtorCompraBuilder.ConstruirPais(idPais);
            _construtorCompraBuilder.ConstruirPessoa(nome,sobrenome);
            _construtorCompraBuilder.ConstruirTelefone(telefone);
        }
    }
}
