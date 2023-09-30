using Microsoft.EntityFrameworkCore;
using Pro401.Entities;

namespace Pro401.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBusinessService _businessService;

        public VehiculoService(ApplicationDbContext context, IBusinessService businessService)
        {
            _context = context;
            _businessService = businessService;
        }
        public async Task<bool> PatenteExiste(string patente)
        {

            var patenteExiste = await _context.Vehiculos.AnyAsync(x => x.Patente == patente);
            if (patenteExiste)
            {
                return true;
            }
            else 
            { 
                return false;
            }

        }

        public bool PrimeraLetraMayuscula(string color) 
        {
           var resultado = _businessService.PrimeraLetraMayuscula(color);
           return resultado;
            
        }

        public async Task Insert(Vehiculo entity)
        {
            _context.Vehiculos.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
