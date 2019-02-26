

namespace Shop.Web.Data
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

    //Clase que será intermediaria entre el controlador y la base de datos
    //Implementa la interfaz Irepository que me pinta la firma de todos los métodos.
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        //Se puede convertir en list, generic collection
        //Retorna la conexión a la base de datos, la lista de productos en orden de nombre
        //Orderby es expresión lambda, usé letra p por products
        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.OrderBy(p => p.Name);
        }

        //Buscar por id, retorna el producto buscando por id (clave primaria)
        public Product GetProduct(int id)
        {
            return this.context.Products.Find(id);
        }

        //Le pasamos el producto y a esa conexión de bd le añadirá el producto
        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }
        //Se actualiza el producto, recibe el producto y sabe cuál actualizar
        public void UpdateProduct(Product product)
        {
            this.context.Products.Update(product);
        }
        //Elimina los productos
        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
        }

        //Método asíncrono, se recomienda que terminen en sufijo async
        //Espera a que los grave, y en la bd guarde lo que tiene pendiente
        //SaveChangesAsync Nos devuelve la cantidad de registros modificados, nos devuelve bool true
        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        //En la conexión búsqueme cualquier producto en la base 
        //de datos es igual al del id que pasamos como parámetro, SI LO ENCUENTRA MUESTRA TRUE
        public bool ProductExists(int id)
        {
            return this.context.Products.Any(p => p.Id == id);
        }

    }
}
