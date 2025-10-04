using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ViajesAPI.Models;
using ViajesAPI.Repositories.Implementations;

namespace ViajesAPI.Repositories.Interfaces
{
    public class ViajeRepository : IViajeRepository
    {
        private ViajesContext _db;

        public ViajeRepository(ViajesContext db)
        {
            _db = db;
        }

        public List<Viaje> GetAll()
        {
      
            return _db.Viajes.Where(v => v.PrecioTotal > 100000).ToList();
        }

        public Viaje? GetById(int id)
        {
            return _db.Viajes.Include(v => v.ViajeDetalles).FirstOrDefault(v => v.Id == id);
        }

        public Viaje? GetFirstByEstado(string estado)
        {
            return _db.Viajes.FirstOrDefault(v => v.Estado == estado);
            .Where(v => v.)


        }

        public List<Viaje> GetViajesCaros()
        {
            return _db.Viajes.Where(v => v.PrecioTotal > 100000).ToList();
        }

        public void UpdateEstado(Viaje viaje, string estado)
        {
            viaje.Estado = estado;
            _db.SaveChanges();
        }

        public void UpdateFecha(Viaje viaje, DateTime nuevaFecha)
        {
            viaje.FechaInicio = nuevaFecha;
            _db.SaveChanges();
        }
    }
}
