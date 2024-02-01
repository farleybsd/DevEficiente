using MongoDB.Driver;

namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Interface
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChange();
        IMongoCollection<T> GetCollection<T>(string name); 
    }
}
