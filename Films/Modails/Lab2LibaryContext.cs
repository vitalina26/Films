using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppDirectors.Modails
{
    public class Lab2LibaryContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<DirectorsFilms> DirectorsFilms { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public Lab2LibaryContext(DbContextOptions<Lab2LibaryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    


    }
}
