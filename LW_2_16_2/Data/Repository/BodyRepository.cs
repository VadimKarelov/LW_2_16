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
    internal class BodyRepository : IRepository<Body>
    {
        private AutoFactoryContext _db;
        private bool _disposed = false;

        public BodyRepository()
        {
            _db = new AutoFactoryContext();
        }

        public void Create(Body item)
        {
            _db.Bodies.Add(item);
        }

        public void Delete(int id)
        {
            Body item = _db.Bodies.Find(id);
            if (item != null)
                _db.Bodies.Remove(item);
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

        public Body Get(int id)
        {
            return _db.Bodies.First(x => x.Id == id);
        }

        public IEnumerable<Body> GetList()
        {
            return _db.Bodies;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Body item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
