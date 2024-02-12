namespace Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> BuscarCategoriaPorNome(string nome);
    }
}