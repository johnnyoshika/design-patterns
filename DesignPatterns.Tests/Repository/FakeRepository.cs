using DesignPatterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DesignPatterns.Tests.Repository
{
    public class FakeRepository<T> : IRepository<T> where T : class, IEntity
    {
        public FakeRepository() : this(Enumerable.Empty<T>())
        {
        }

        public FakeRepository(IEnumerable<T> entities) => Set = new HashSet<T>(entities);

        HashSet<T> Set { get; }
        IQueryable<T> QueryableSet => Set.AsQueryable();

        public IQueryable<T> FindAll() => QueryableSet;

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate) => QueryableSet.Where(predicate);

        public T FindById(int id) => QueryableSet.FirstOrDefault(i => i.Id == id);

        public void Add(T entity) => Set.Add(entity);

        public void Remove(T entity) => Set.Remove(entity);
    }
}
