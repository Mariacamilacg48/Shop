namespace Shop.Web.Data
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        //Inyecta la conexión a la base de datos, datacontext viene inyectado
        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        //Alimenta la base de datos
        //EnsurecreATEASYNC, COMO ES CODE FIRST, NO SE SABE SI LA BD ESTÁ CREADA, Y ESPERA A QUE LA CREE
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            //context: conexión bd products: colección de productos, any: si al menos hay registros devuelve true
            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X");
                this.AddProduct("Magic Mouse");
                this.AddProduct("iWatch Series 4");
                await this.context.SaveChangesAsync();
            }
        }

        //Al conexto(Conexión de producto) añadir nuevo producto, el que te pasaron por parámetro
        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }
    }

}

