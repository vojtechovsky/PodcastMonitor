using System.Collections.Generic;

namespace PodcastMonitor.Stores
{
    public interface IPaged<T>
    {
        IEnumerable<T> Items { get; }
        int TotalItemCount { get; }
        int Page { get; }
        int TotalPages { get; }
    }
}