namespace Shop.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using Data;

    //Rutear el API, cuando publiquemos el sitio web quedará así

    [Route("api/[Controllers]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        //Método naturaleza get, get de mi controlador
        [HttpGet]
        public IActionResult GetProducts()
        {
            return this.Ok(this.productRepository.GetAll());
        }


    }
}
