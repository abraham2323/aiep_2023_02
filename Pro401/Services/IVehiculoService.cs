using Pro401.Entities;

namespace Pro401.Services
{
    public interface IVehiculoService
    {
        Task<bool> PatenteExiste(string patente);
        bool PrimeraLetraMayuscula(string color);
        Task Insert(Vehiculo entity);
    }
}