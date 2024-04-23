namespace Com.DevEficiente.CasaDoCodigo.Domain.Builders
{
    public interface IConstrutorCompraBuilder
    {
        void ConstruirEmail(string email);

        void ConstruirPessoa(string nome, string sobrenome);

        void ConstruirDocumentoCompra(string documento);

        void ConstruirLocalizacao(string endereco, string complemento, string cidade, string cep);

        void ConstruirPais(string nome);

        void ConstruirEstado(string idPais, string nomeEstado);

        void ConstruirTelefone(string numero_Telefone);

        Compra ObterCompra();
    }
}