﻿using System.Collections.Generic;

namespace PodcastMonitor.DataRepository
{
    public interface IDataRepository<out T>
    {
        IEnumerable<T> GetData(string sortBy);

        IEnumerable<T> GetDataForUser(string sortBy, int userId);
    }
}
