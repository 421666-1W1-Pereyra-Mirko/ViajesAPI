using ViajesAPI.Models;

namespace ViajesAPI.Services.Implementations
{
    public interface IViajeService
    {
        List<Viaje> GetAll();
        Viaje GetById(int id);
        Viaje GetFirstByEstado(string estado);
        List<Viaje> GetViajesCaros();
        void UpdateEstado(int id, string estado);
        void UpdateFecha(int id, DateTime nuevaFecha);
    }
}
