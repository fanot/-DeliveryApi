using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.Json.Serialization;
using WebApi.Entities;

namespace WebApi.Entities
{
    public class Cart

    {
       [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
   
        public string Id { get; set; }
        public Entities.Dish Dish { get; set; }
        public Entities.Users Users { get; set; }

        public double? TotalPrice { get; set; }

        public int? Amount { get; set; }
        public Order Orders { get; set; }

    }

}
