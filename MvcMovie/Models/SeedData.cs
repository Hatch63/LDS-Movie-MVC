using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Relgious Adventure",
                        Rating = "PG",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Meet the Mormon",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Documentary",
                        Rating = "PG-13",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "The Testaments",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Gospel",
                        Rating = "PG",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}