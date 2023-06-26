using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Online_magazine_Diploma.DataAccess;
using Online_magazine_Diploma.DataAccess.DbPatterns;
using Online_magazine_Diploma.DataAccess.DbPatterns.Interfaces;
using Online_magazine_Diploma.Services.Interfaces;
using Online_magazine_Diploma.Services.Service;
using System.Security.Claims;

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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

			app.UseAuthentication();

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

			//-----------------
			//app.MapGet("/login", async (HttpContext context) =>
			//{
			//	var claimsIdentity = new ClaimsIdentity("Undefined");
			//	var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			//	// установка аутентификационных куки
			//	await context.SignInAsync(claimsPrincipal);
			//	return Results.Redirect("/");
			//});

			//app.MapGet("/logout", async (HttpContext context) =>
			//{
			//	await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//	return "Данные удалены";
			//});
			//app.Map("/", (HttpContext context) =>
			//{
			//	var user = context.User.Identity;
			//	if (user is not null && user.IsAuthenticated)
			//	{
			//		return $"Пользователь аутентифицирован. Тип аутентификации: {user.AuthenticationType}";
			//	}
			//	else
			//	{
			//		return "Пользователь НЕ аутентифицирован";
			//	}
			//});
			//=====================

			app.Run();
        }
    }
}