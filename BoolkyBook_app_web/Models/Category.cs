using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoolkyBook_app_web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nom")]
        public string Name { get; set; }
        [DisplayName("Numéro de commande")]
        public int DisplayOrder { get; set; }
        [DisplayName("Date de Creation")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
