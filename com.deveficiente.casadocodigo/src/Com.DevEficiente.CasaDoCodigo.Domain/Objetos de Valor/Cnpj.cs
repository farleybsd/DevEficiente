using System.Text.RegularExpressions;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class Cnpj
    {
        private string _cnpj;

        public string Valor
        {
            get { return _cnpj; }
            private set
            {
                if (!ValidarCnpj(value))
                    throw new ArgumentException("CNPJ inválido", nameof(value));
                _cnpj = value;
            }
        }

        public Cnpj(string cnpj)
        {
            Valor = cnpj;
        }

        private bool ValidarCnpj(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = Regex.Replace(cnpj, @"[^\d]", "");

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores1[i];
            }
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores2[i];
            }
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores calculados são iguais aos informados
            return int.Parse(cnpj[12].ToString()) == digitoVerificador1 && int.Parse(cnpj[13].ToString()) == digitoVerificador2;
        }
    }
}