namespace Shop.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    //Clase donde tendremos las entidades, code first significa que nuestra base de datos depende de nuestro código
    public class Product
    {
        //Clave numérica autoincrementable, necesaria, la clave primaria
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
        [Required]
        public string Name { get; set; }

        //Decorados, appmodificaciones que se colocan a los atributos para que se despliegue diferente
        //DisplayFormat C2: formato currency 2, con el indicador de moneda, usa el que tenga configurado la máquina
        //Separación de miles, con dos decimales (C2) y el ApplyFormat hace que no salga con símbolo de pesos, solo para mostrar
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        //Ruta de la imagen. El display hace que el usuario le vea el nombre Image, pero para mí es ImageUrl
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //Last purchase para el usuario, para mí el display es LastPurchase
        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Availabe?")]
        public bool IsAvailabe { get; set; }

        //N2 numérico de 2, el otro le pone símbolo de pesos, solo le coloca separadores de miles y 2 decimales
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
    }
}

