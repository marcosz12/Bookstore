<<<<<<< HEAD
using BookStore.Data;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;

=======
>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
<<<<<<< HEAD
            builder.Services.AddScoped<GenreService>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseMySql(
                    builder
                        .Configuration
                        .GetConnectionString("BookstoreContext"),
                    ServerVersion
                        .AutoDetect(
                            builder
                                .Configuration
                                .GetConnectionString("BookstoreContext")
                        )
                );
            });
=======

            // Add services to the container.
            builder.Services.AddControllersWithViews();

>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
<<<<<<< HEAD
=======
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
                app.UseHsts();
            }

            app.UseHttpsRedirection();
<<<<<<< HEAD

=======
>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
