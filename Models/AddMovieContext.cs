
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission4.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options)
        {

        }
        public DbSet<AddMovieModel> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action / Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror / Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneious" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "Thriller" },
                new Category { CategoryId = 9, CategoryName = "VHS" }


            );


            mb.Entity<AddMovieModel>().HasData(

                new AddMovieModel
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Karate Kid",
                    Year = 1984,
                    Director = "John Avildsen",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "Danny was the real bully"



                },

                new AddMovieModel
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Turn the brightness up"

                },
                new AddMovieModel
                {
                    MovieId = 3,
                    CategoryId = 8,
                    Title = "Dune",
                    Year = 2022,
                    Director = "Deniss Villenueve",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Kwisatz Haderach"

                }
            );
        }
    }
}

