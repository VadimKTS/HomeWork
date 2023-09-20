using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Online_magazine_Diploma.DataAccess;
using Online_magazine_Diploma.DataAccess.DbPatterns;
using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.Services.Interfaces;
using Online_magazine_Diploma.Services.Service;

namespace Online_magazine_Diploma
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddControllersWithViews();
			//swagger
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMvcCore();
            builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
			});

			builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<IArticleTypeService, ArticleTypeService>();
			builder.Services.AddTransient<IArticleService, ArticleService>();
			builder.Services.AddTransient<ITitelService, TitelService>();
			builder.Services.AddTransient<ICommentService, CommentService>();

			

			// Аутентификация с помощью куки
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(option =>
				{
					option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
					option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
				});

			var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

			//swagger 
			//localhost:5248/swagger/v1/swagger.json
			//localhost:5248/swagger
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
				});
			}

			app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

			app.UseAuthentication();

            app.UseHttpsRedirection();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
			
		}
    }
}