using Microsoft.EntityFrameworkCore;
using TasksEvaluation.Core.Interfaces.IRepositories;
using TasksEvaluation.Infrastructure.Data;
namespace TasksEvaluation.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbcontext;
        protected DbSet<T> DbSet=>_dbcontext.Set<T>();
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAll()=> await DbSet.AsNoTracking().ToListAsync();

        public async Task<T> GetById<Tid>(Tid id)
        {
            var data=await DbSet.FindAsync(id);
            if (data == null)
                throw new DirectoryNotFoundException("No data found");
            return data;
        }
        public async Task<T>Create(T model)
        {
            await DbSet.AddAsync(model);
            await SaveChangeAsync();
            return model;
        }
        public async Task CreateRange(List<T> model)
        {
            await DbSet.AddRangeAsync(model);
            await SaveChangeAsync();
        }
        public async Task Update(T model)
        {
            DbSet.Update(model);
            await SaveChangeAsync();
        }
        public async Task Delete(T model)
        {
            DbSet.Remove(model);
            await SaveChangeAsync();
        }
        public async Task SaveChangeAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
