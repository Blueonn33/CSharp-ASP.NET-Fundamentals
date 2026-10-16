namespace MyBlog.Data.Common
{
    public interface IRepository
    {
        // IQueryable could not be async
        IQueryable<T> All<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
