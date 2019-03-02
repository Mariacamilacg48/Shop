namespace Shop.Web.Data
{

    using Entities;

    //PRoduct repository hereda el generic repository con product, e implementa interfaz IproductRepository

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        //Inyecta el data context y el datacontext que le inyecta se lo pasa al constructor de la clase base, la super clase
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }

}

