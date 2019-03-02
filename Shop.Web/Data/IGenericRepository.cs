

namespace Shop.Web.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    //Repositorio genérico, la T representa una entidad, podemos poner cualquiera
    public interface IGenericRepository<T> where T : class
    {
        //Get all, nos devuelve lista de la entidad
        IQueryable<T> GetAll();

        //PAsamos parámetro ID, y nos devuelve una entidad
        Task<T> GetByIdAsync(int id);

        //Crea una entidad
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);
    }

}
