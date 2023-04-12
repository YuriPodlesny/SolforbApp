namespace SolforbApp.Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable
        where T : class
    {
        Task<bool> Create(T entety);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
        void Save();
        IEnumerable<T> GetAll();
        Task<T?> Get(int id);
    }
}
