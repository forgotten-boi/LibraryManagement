using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibMS.Api.Helpers;
using LibMS.Services.IServices;
using LibMS.Services.Services;
using LibMS.Repository.Repositories;
using LibMS.Entity.ViewModel;
using Microsoft.EntityFrameworkCore;
using LibMS.Services.Interface;

namespace LibMS.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCountRepository, BookCountRepository>();
            services.AddScoped<IAssignBookRepository, AssignBookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookCountService, BookCountService>();
            services.AddScoped<IAssignBookService, AssignBookService>();
            services.AddScoped<IUserService, UserService>();

           

            services.AddDbContext<LibMS.DataAccess.ProjectDbContext>(options =>
             options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("LibMS.Api")
             ));
        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
