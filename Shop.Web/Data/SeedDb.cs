namespace Shop.Web.Data
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Helpers;
    using Microsoft.AspNetCore.Identity;
    

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        //Inyecta la conexión a la base de datos, datacontext viene inyectado
        public SeedDb(DataContext context, IUserHelper UserHelper)
        {
            this.context = context;
            this.userHelper = UserHelper;
            this.random = new Random();
        }

        //Alimenta la base de datos
        //EnsurecreATEASYNC, COMO ES CODE FIRST, NO SE SABE SI LA BD ESTÁ CREADA, Y ESPERA A QUE LA CREE
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            //Busque si ya existe ese usuario
            var user = await this.userHelper.GetUserByEmailAsync("jzuluaga55@gmail.com");

            //Si no existe, nuevo usuario
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Juan",
                    LastName = "Zuluaga",
                    Email = "jzuluaga55@gmail.com",
                    UserName = "jzuluaga55@gmail.com",
                    PhoneNumber = "3506342747"
                };
                //Contraseña
                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            //context: conexión bd products: colección de productos, any: si al menos hay registros devuelve true
            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        //Al conexto(Conexión de producto) añadir nuevo producto, el que te pasaron por parámetro
        private void AddProduct(string name, User User)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = User
            });
        }
    }

}

