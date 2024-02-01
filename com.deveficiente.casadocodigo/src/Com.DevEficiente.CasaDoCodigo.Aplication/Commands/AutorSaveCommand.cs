using Com.DevEficiente.CasaDoCodigo.Aplication.Response;
using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;
using MediatR;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class AutorSaveCommand : IRequest<AutorResponse>
    {
        public AutorSaveCommand(string nome, Email email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public string Descricao { get; private set; }
    }
}
