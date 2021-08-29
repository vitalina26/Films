using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDirectors.Modails
{
    public class Film
    {
        public Film()
        {
            DirectorsFilms = new List<DirectorsFilms>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<DirectorsFilms> DirectorsFilms { get; set; }
    }
}
