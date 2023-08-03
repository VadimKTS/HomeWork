using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
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
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<IArticleTypeService, ArticleTypeService>();
			builder.Services.AddTransient<IArticleService, ArticleService>();
			builder.Services.AddTransient<ITitelService, TitelService>();
			builder.Services.AddTransient<ICommentService, CommentService>();

			

			// �������������� � ������� ����
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
				app.UseSwaggerUI();
			}

			app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

			app.UseAuthentication();

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
			
		}
    }
}