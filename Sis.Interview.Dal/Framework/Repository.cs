using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sis.Interview.Models;

namespace Sis.Interview.Dal.Framework
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly Hashtable _storage;

        public Repository()
        {
            _storage = new Hashtable();
        }

        public IEnumerable<T> All()
        {
            return new List<T>(_storage.Values.Cast<T>());
        }

        public IEnumerable<T> All(Func<T, bool> filterPredicate)
        {
            return filterPredicate == null ? All() : All().Where(filterPredicate);
        }

        public T Save(T item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
                throw new NullReferenceException(item.Name);
            if (_storage.Contains(item.Name))
                _storage[item.Name] = item;
            else
                _storage.Add(item.Name, item);
            return item;
        }

        public T FindById(string name)
        {
            return _storage.Contains(name) ? (T)_storage[name] : default(T);
        }
    }
}
