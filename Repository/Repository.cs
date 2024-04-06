using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        protected Repository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
            : RepositoryContext.Set<T>().Where(expression);

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await RepositoryContext.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await RepositoryContext.Set<T>().FindAsync(id);
    }
}
