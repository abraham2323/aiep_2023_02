using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pro401.DTO.VehiculoDTO;
using Pro401.Entities;
using Pro401.Services;

namespace Pro401.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        
        private readonly IVehiculoService _vehiculoService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public VehiculoController(IVehiculoService vehiculoService, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _vehiculoService = vehiculoService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        
        public async Task<ActionResult> Get()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim=>claim.Type == "email").FirstOrDefault();
            var email = emailClaim != null ? emailClaim.Value : null;
            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
            }
            return Ok("HTTP GET");
        }

        [HttpPost]
        public async Task <ActionResult> Post(VehiculoCreateDTO model)
        {
            //verificar si patente existe en DB

            var patenteExiste = await _vehiculoService.PatenteExiste(model.Patente);

            //Si existe retornar un error

            if (patenteExiste)
            {
                return BadRequest("La patente ya fue ingresada");
            }

            //Patente debe tener la primera letra mayuscula

            if (!_vehiculoService.PrimeraLetraMayuscula(model.Color))
            {
                return BadRequest("La primera letra debe ser MAYUSCULA");
            }

            //insertar registro en la base de datos

            var entity = _mapper.Map<Vehiculo>(model); //no instanciar,  mapeo
            await _vehiculoService.Insert(entity);
            return Ok("Registro guardado");
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Put()
        {
            return Ok("HTTP PUT");
        }

        [HttpPatch]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Patch()
        {
            return Ok("HTTP PATCH");
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "isAdminClaim")]

        public ActionResult Delete()
        {
            return Ok("HTTP Delate");
        }
    }
}
