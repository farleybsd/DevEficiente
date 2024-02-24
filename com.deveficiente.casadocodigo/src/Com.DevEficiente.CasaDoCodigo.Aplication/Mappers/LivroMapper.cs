using Com.DevEficiente.CasaDoCodigo.Aplication.Request;
using Riok.Mapperly.Abstractions;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Mappers
{
    [Mapper]
    public partial class LivroMapper
    {
        public partial LivroSaveCommand RequestToCommand(LivroCreateRequest livro);
    }
}