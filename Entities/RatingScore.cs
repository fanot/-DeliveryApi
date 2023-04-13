using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
   public class RatingScore
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public string Id { get; set; }

        [ForeignKey("Users")]
    
        public string UserId { get; set; }
        [Range(0, 10, ErrorMessage = "The field {0} must be greater than {1} and less than {2}.")]
        public int? Rating { get; set; }
        [ForeignKey("Dish")]
       
        public string DishId { get; set; }
        public Entities.Users Users { get; set; }

    }
}
