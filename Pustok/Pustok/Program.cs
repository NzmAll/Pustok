namespace Pustok
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Services
            builder.Services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            var app = builder.Build();

            //Middleware
            app.UseStaticFiles();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}