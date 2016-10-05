using System;
using System.Collections.Generic;
using Sis.Interview.Models;

namespace Sis.Interview.Dal.Framework
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> All();
        IEnumerable<T> All(Func<T, bool> filterPredicate);
        T Save(T item);
        T FindById(string name);
    }
}
