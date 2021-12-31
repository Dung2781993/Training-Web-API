using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected UniversityEntities _universityEntities { get; set; }
        protected DbSet<T> _tables = null;

        public GenericRepository()
        {
            _universityEntities = new UniversityEntities();
            _tables = _universityEntities.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return _tables.ToList();
        }
        public void Delete(object id)
        {
            T existing = _tables.Find(id);
            _tables.Remove(existing);
        }

        public void Insert(T obj)
        {
            _tables.Add(obj);
        }

        public void Save()
        {
            _universityEntities.SaveChanges();
        }


        public T SelectById(object Id)
        {
            try
            {
                return _tables.Find(Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(T obj)
        {
            _tables.Attach(obj);
            _universityEntities.Entry(obj).State = EntityState.Modified;
        }
    }
}