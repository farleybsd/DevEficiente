using System.Text.RegularExpressions;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class Cpf
    {
        private string _cpf;

        public string Valor
        {
            get { return _cpf; }
            private set
            {
                if (!ValidarCpf(value))
                    throw new ArgumentException("CPF inválido", nameof(value));
                _cpf = value;
            }
        }

        public Cpf(string cpf)
        {
            Valor = cpf;
        }

        private bool ValidarCpf(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais, o que é inválido
            bool todosIguais = true;
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[i - 1])
                {
                    todosIguais = false;
                    break;
                }
            }
            if (todosIguais)
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicadores1[i];
            }
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicadores2[i];
            }
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores calculados são iguais aos informados
            return int.Parse(cpf[9].ToString()) == digitoVerificador1 && int.Parse(cpf[10].ToString()) == digitoVerificador2;
        }
    }
}