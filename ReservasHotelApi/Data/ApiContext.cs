using Microsoft.EntityFrameworkCore;
using ReservasHotelApi.Models;

namespace ReservasHotelApi.Data
{
    public class ApiContext : DbContext
    {

        public DbSet<ReservasHotel> Reservas {  get; set; }
        public ApiContext(DbContextOptions<ApiContext> opcoes) :base(opcoes)
        { 
        } 

    }
}
