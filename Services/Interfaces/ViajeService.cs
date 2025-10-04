using ViajesAPI.Models;
using ViajesAPI.Repositories.Implementations;
using ViajesAPI.Services.Implementations;

namespace ViajesAPI.Services.Interfaces
{
    public class ViajeService : IViajeService
    {
        private IViajeRepository _repository;

        public ViajeService(IViajeRepository repository)
        {
            _repository = repository;
        }

        public List<Viaje> GetAll()
        {
            return _repository.GetAll();
        }

        public Viaje GetById(int id)
        {
            Viaje viaje = _repository.GetById(id);

            if (viaje == null)
            {
                throw new ArgumentException("el viaje no existe.");
            }

            return viaje;
        }

        public Viaje GetFirstByEstado(string estado)
        {
            var viaje = _repository.GetFirstByEstado(estado);
            if (string.IsNullOrEmpty(estado))
            {
                throw new ArgumentException("el estado no puede ser nulo o vacío.");
            }

            return _repository.GetFirstByEstado(estado);
        }

        public List<Viaje> GetViajesCaros()
        {
            return _repository.GetViajesCaros();
        }

        public void UpdateEstado(int id, string estado)
        {
            Viaje viaje = _repository.GetById(id);

            if (viaje == null)
            {
                throw new ArgumentException("El viaje no existe.");
            }

            if (viaje.Estado != "Pendiente")
            {
                throw new InvalidOperationException("Solo se pueden actualizar viajes en estado 'Pendiente'.");
            }

            _repository.UpdateEstado(viaje, estado);
        }

        public void UpdateFecha(int id, DateTime nuevaFecha)
        {
            Viaje viaje = _repository.GetById(id);

            if (viaje == null)
            {
                throw new ArgumentException("El viaje no existe.");
            }

            if (nuevaFecha > viaje.FechaFin)
            {
             
                throw new InvalidOperationException("La nueva fecha no puede ser posterior a la fecha de fin del viaje.");
               
            }


            _repository.UpdateFecha(viaje, nuevaFecha);
           
        }
    }
}
