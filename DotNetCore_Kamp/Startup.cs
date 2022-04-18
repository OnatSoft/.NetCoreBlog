using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp
{
    public class Startup         /**** Startup Sýnýfý, bir projenin MVC'de WebConfig gibi Ayarlar sýnýfý ****/
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<Context>();

            services.AddControllersWithViews();

            services.AddSession(); //*** Yazar Giriş Sayfasında Oturumu Ekle Methodu - Session İşlemleri ***//

            services.AddMvc(config =>  //*** Bütün Proje seviyesinde bir Authorize, Authenticate Tanımlaması. Yani sitede ki bütün sayfalara kullanıcı giriş zorunluluğu getiriliyor. ***//
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(  //*** Diğer sayfalara geçiş yaparken kullanıcının karşısına hata vermemesi için Giriş sayfasında "Return URL" yapıyor. ***//
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                });

            services.ConfigureApplicationCookie(options =>
            {
                // Web Site Uygulama Cookie Ayarları
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Login/AdminIndex/";
                options.SlidingExpiration = true;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");  //--- Özelleştirilmiş 404 Sayfası yapımı başlangıç dizini

            //*** app.UseSession();

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
