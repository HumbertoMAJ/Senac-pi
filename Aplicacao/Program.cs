using Aplicacao.Data;
using Aplicacao.Helper;
using Aplicacao.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Aplicacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<BancoContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IProfissionalRepositorio, ProfissionalRepositorio>();

            builder.Services.AddScoped<IagendamentoRepositorio, AgendamentoRepositorio>();

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<ISessao, Sessao>();

           

            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });


           var app = builder.Build();

            /*builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>();*/



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}