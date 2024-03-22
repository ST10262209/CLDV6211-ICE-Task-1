using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcGame.Data;
using MvcGame.Models;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcGameContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcGameContext>>()))
        {
            // Look for any movies.
            if (context.Game.Any())
            {
                return;   // DB has been seeded
            }
            context.Game.AddRange(
                new Game
                {
                    Title = "Destiny 2",
                    Rating = "R",
                    ReleaseDate = DateTime.Parse("2017-9-6"),
                    Genre = "FPS and Action MMO",
                    Price = 1200M

                },
                new Game
                {
                    Title = "Genshin Impact",
                    Rating = "G",
                    ReleaseDate = DateTime.Parse("2020-9-28"),
                    Genre = "Action Role-Playing Game",
                    Price = 0M
                },
                new Game
                {
                    Title = "Honkai Star Rail",
                    Rating = "G",
                    ReleaseDate = DateTime.Parse("2023-4-26"),
                    Genre = "Action Role-Playing Game",
                    Price = 0M
                },
                new Game
                {
                    Title = "Baldurs Gate 3",
                    Rating = "NC-17",
                    ReleaseDate = DateTime.Parse("2023-8-3"),
                    Genre = "Role-Playing Game",
                    Price = 800M
                }
            );
            context.SaveChanges();
        }
    }
}
