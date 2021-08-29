using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebAppDirectors.Modails
{
    public class Category
    {
        public Category()
        {
            Films = new List<Film>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Катигорія")]
        public string Name { get; set; }
        [Display(Name = "Інформація про категорію")]
        public string Info { get; set; }
        
        public virtual ICollection<Film> Films { get; set; }
    
    }
}
