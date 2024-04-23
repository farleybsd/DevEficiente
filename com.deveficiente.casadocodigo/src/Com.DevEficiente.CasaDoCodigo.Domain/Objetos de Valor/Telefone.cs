namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class Telefone
    {
        public string Numero_Telefone { get; private set; }

        public Telefone(string numero_Telefone)
        {
            if (string.IsNullOrWhiteSpace(numero_Telefone))
                throw new ArgumentException("O numero_Telefone não pode ser nulo, vazio ou conter apenas espaços em branco", nameof(numero_Telefone));
            Numero_Telefone = numero_Telefone;
        }
    }
}