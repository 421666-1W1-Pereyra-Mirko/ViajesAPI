using ViajesAPI.Models;

namespace ViajesAPI.Repositories.Implementations
{
    public interface IViajeRepository
    {
        List<Viaje> GetAll();
        Viaje? GetById(int id);
        Viaje? GetFirstByEstado(string estado);
        List<Viaje> GetViajesCaros();
        void UpdateEstado(Viaje viaje, string estado);
        void UpdateFecha(Viaje viaje, DateTime nuevaFecha);
    }
}
