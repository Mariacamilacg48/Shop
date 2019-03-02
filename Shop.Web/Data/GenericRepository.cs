

namespace Shop.Web.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    //Implementación genérica de T, implementará interfaz genérica T, donde T es una clase
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext context;

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }

        //Lista que vamos a devolver, ass no tracking para que funcione el método genérico
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        //Busque productos donde el código sea igual al código del parámetro
        public async Task<T> GetByIdAsync(int id)
        {
            return await this.context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        //Adicione asíncrono ese modelo
        public async Task CreateAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            await SaveAllAsync();
        }

        //Actualiza y graba cambio
        public async Task UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);
            await SaveAllAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.context.Set<T>().AnyAsync(e => e.Id == id);

        }

        //No es tan necesario ya que se usa en los otros métodos asíncronos de arriba
        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }

}
