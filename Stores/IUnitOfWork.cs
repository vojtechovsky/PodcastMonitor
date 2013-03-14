namespace Stores
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}