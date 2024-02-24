namespace Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<bool> IsTituloUnique(string titulo);
    }
}