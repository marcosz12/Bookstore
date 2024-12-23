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
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<BookService>();
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

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
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

