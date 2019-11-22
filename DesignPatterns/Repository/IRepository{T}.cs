using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DesignPatterns.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T FindById(int id);

        void Add(T entity);
        void Remove(T entity);
    }

    public interface IEmployeeRepository : IRepository<Employee>
    {
        IQueryable<Employee> GetAllManagers(); // Optionally define an IEmployeeRepository to expose special methods for empoyees
    }

    // Example repository that works with EF
    // Our production code (e.g. controller) would work with IRepository<Employee> and DI would inject SqlRepository<T>
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        public T FindById(int id)
        {
            var list = new List<T>(); // assume this list comes from the database;
            return list.FirstOrDefault(i => i.Id == id); // can access i.Id here because we added a generic constraint of class and IEntity
        }

        public IQueryable<T> FindAll() => throw new NotImplementedException();
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate) => throw new NotImplementedException();
        public void Add(T entity) => throw new NotImplementedException();
        public void Remove(T entity) => throw new NotImplementedException();
    }

}
