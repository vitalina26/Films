using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDirectors.Modails
{
    public class DirectorsFilms
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int DirectorId { get; set; }
      

        public virtual Film Film { get; set; }
        public virtual Director Director { get; set; }
    }
}
