using MeetupAPI.Data;
using MeetupAPI.Interfaces;
using MeetupAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeetupAPI.Repositories
{
    public class EfRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        private readonly MeetupAPIDbContext dbContext;

        public EfRepository(MeetupAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<long> AddAsync(T entity)
        {
            var result = await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<bool> UpdateAsync(long id, T entity)
        {
            var result = await dbContext.Set<T>().FindAsync(id);

            if (result != null)
            {
                var newProps = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var oldProps = result.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                for (int i = 0; i < newProps.Length; i++)
                    if (oldProps[i].Name != "Id")
                        oldProps[i].SetValue(result, newProps[i].GetValue(entity));
                
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await dbContext.Set<T>().FindAsync(id);

            if (result != null)
            {
                dbContext.Set<T>().Remove(result);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
