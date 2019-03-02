namespace Shop.Web.Data
{
    using Shop.Web.Data.Entities;

    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        //Inyecta el data context y el datacontext que le inyecta se lo pasa al constructor de la clase base, la super clase
        public CountryRepository(DataContext context) : base(context)
        {
        }
    }
}
