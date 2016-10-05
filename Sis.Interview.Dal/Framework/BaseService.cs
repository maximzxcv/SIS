using System;
using System.Collections.Generic;
using Sis.Interview.Models;

namespace Sis.Interview.Dal.Framework
{
    public abstract class BaseService<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        protected BaseService(IRepository<T> repository)
        {
            _repository = repository;
        } 

        public virtual IEnumerable<T> Get(Func<T, bool> filterPredicate = null)
        {
            return _repository.All(filterPredicate);
        }

        public virtual T Get(string name)
        {
            return _repository.FindById(name);
        }

        public virtual T Create(T itemToCreate)
        {
            return _repository.Save(itemToCreate); 
        }

        public virtual T Save(T itemToSave)
        {
            return _repository.Save(itemToSave); 
        }
    }
}
