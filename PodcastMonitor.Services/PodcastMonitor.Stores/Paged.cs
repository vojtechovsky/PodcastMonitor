using System;
using System.Collections.Generic;
using System.Linq;

namespace PodcastMonitor.Stores
{
    public class Paged<T> : IPaged<T>
    {
        public Paged(IQueryable<T> itemsQuery, int page, int pageSize)
        {
            TotalItemCount = itemsQuery.Count();

            var recordsToSkip = pageSize * (page - 1);

            Page = page;

            TotalPages = (int)Math.Ceiling(TotalItemCount / (float)pageSize);

            Items = itemsQuery.Skip(recordsToSkip).Take(pageSize).ToList();
        }

        public IEnumerable<T> Items { get; private set; }

        public int TotalItemCount { get; private set; }

        public int Page { get; private set; }

        public int TotalPages { get; private set; }
    }
}