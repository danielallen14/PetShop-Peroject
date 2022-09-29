namespace PetShop.Client.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Get(int ?id);
        IQueryable<T> GetAll();
        T Delete (int id);
    }
}
