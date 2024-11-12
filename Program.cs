using BookStore.Data;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
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
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}