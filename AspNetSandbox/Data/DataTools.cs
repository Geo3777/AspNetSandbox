using AspNetSandbox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Data
{
    public class DataTools
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The books are there");

                }
                else
                {
                    Console.WriteLine("No books");
                    var book1 = new Book();
                    book1.Id = 1;
                    book1.Title = "The Old Book";
                    book1.Author = "George";
                    book1.Language = "English";
                    applicationDbContext.Add(book1);
                    var book2 = new Book();
                    book2.Id = 2;
                    book2.Title = "The New Book";
                    book2.Author = "Otgon";
                    book2.Language = "English";
                    applicationDbContext.Add(book2);
                    applicationDbContext.SaveChanges();
                }
            }
        }
    }
}
