namespace PodcastMonitor.Stores
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}