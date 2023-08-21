using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.DataAccess
{
    public class CaravanMvcContext : DbContext
    {
        public CaravanMvcContext(DbContextOptions<CaravanMvcContext> options) : base(options)
        {

        }
    }
}