using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservasHotelApi.Models;
using ReservasHotelApi.Data;

namespace ReservasHotelApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservasHotelController : ControllerBase
    {
        private readonly ApiContext _context;

        public ReservasHotelController(ApiContext context)
        {
            _context = context;   
        }

        [HttpPost]
        public JsonResult CriarEditar(ReservasHotel reservas)
        {
            if ( reservas.Id == 0)
            {
                _context.Reservas.Add(reservas);
            }
            else
            {
                var reservasNaBase = _context.Reservas.Find(reservas.Id);

                if (reservasNaBase == null)
                {
                    return new JsonResult(NotFound());
                }
                reservasNaBase = reservas;
            }

            _context.SaveChanges();
            return new JsonResult(Ok(reservas));
        }

        [HttpGet]
        public JsonResult RetornaReserva(int id)
        {
            var resultado = _context.Reservas.Find(id);

            if (resultado == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(resultado));
        }

        [HttpDelete]
        public JsonResult DeletaReserva(int id)
        {
            var resultado = _context.Reservas.Find(id);

            if (resultado == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Reservas.Remove(resultado);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        [HttpGet("/BuscaTodos")]
        public JsonResult BuscaTodos()
        {
            var resultado = _context.Reservas.ToList();

            return new JsonResult(Ok(resultado));
        }

    }
}
