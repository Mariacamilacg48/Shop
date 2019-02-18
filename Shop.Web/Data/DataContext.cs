

namespace Shop.Web.Data
{
    
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;

    //Clase que me hará la conexión con la base de datos.
    public class DataContext : DbContext
    {
        //Cada tabla es una propiedad en la tabla de datos, creamos propiedad para tabla product
        //Propiedad tipo DbSet del modelo que se va a tirar a base de datos (modelo products)
        //Products se va a mapear como una tabla en el entity framework
        public DbSet <Product> Products { get; set; }
        //Constructor ctor tab tab
        //recibe db context options y lo pasamos a constructor base
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }

}
