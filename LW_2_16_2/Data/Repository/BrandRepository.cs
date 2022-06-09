using LW_2_16_2.Data.Interfaces;
using LW_2_16_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_16_2.Data.Repository
{
    internal class BrandRepository : IRepository<Brand>
    {
        private AutoFactoryContext _db;
        private bool _disposed = false;

        public BrandRepository()
        {
            _db = new AutoFactoryContext();
        }

        public void Create(Brand item)
        {
            _db.Brands.Add(item);
        }

        public void Delete(int id)
        {
            Brand item = _db.Brands.Find(id);
            if (item != null)
                _db.Brands.Remove(item);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Brand Get(int id)
        {
            return _db.Brands.First(x => x.Id == id);
        }

        public IEnumerable<Brand> GetList()
        {
            return _db.Brands;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Brand item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
