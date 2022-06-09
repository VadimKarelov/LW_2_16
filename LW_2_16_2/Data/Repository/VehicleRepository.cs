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
    internal class VehicleRepository : IRepository<Vehicle>
    {
        private AutoFactoryContext _db;
        private bool _disposed = false;

        public VehicleRepository()
        {
            _db = new AutoFactoryContext();
        }

        public void Create(Vehicle item)
        {
            _db.Vehicles.Add(item);
        }

        public void Delete(int id)
        {
            Vehicle item = _db.Vehicles.Find(id);
            if (item != null)
                _db.Vehicles.Remove(item);
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

        public Vehicle Get(int id)
        {
            return _db.Vehicles.First(x => x.Id == id);
        }

        public IEnumerable<Vehicle> GetList()
        {
            return _db.Vehicles;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Vehicle item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
