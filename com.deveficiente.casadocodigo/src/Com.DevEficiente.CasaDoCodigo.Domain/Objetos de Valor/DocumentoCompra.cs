namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    using System;
    using System.Text.RegularExpressions;

    namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
    {
        public  class DocumentoCompra
        {
            public string _documento { get; private set; }

            public DocumentoCompra(string documento)
            {
                _documento = documento;
            }

            public DocumentoCompra CriarDocumento()
            {
                if (Regex.IsMatch(_documento, @"^\d{11}$")) // Verifica se a string consiste exatamente em 11 dígitos, o que é o formato de um CPF.
                {
                    var cpf = new Cpf(_documento);
                    return new DocumentoCompra(cpf.Valor);
                }
                else if (Regex.IsMatch(_documento, @"^\d{14}$")) // Verifica se a string consiste exatamente em 14 dígitos, o que é o formato de um CNPJ.
                {
                    var cnpj = new Cnpj(_documento);
                    return new DocumentoCompra(cnpj.Valor);
                }
                else
                {
                    throw new ArgumentException("Documento inválido", nameof(_documento));
                }
            }
        }
    }

}
