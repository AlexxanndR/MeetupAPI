using MeetupAPI.Entities;

namespace MeetupAPI.Interfaces
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<long> AddAsync(T entity);
        Task<bool> UpdateAsync(long id, T entity);
        Task<bool> DeleteAsync(long id);
    }
}
