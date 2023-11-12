using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.AspNetCore.Http;
using WebBanHang.Models.Entities;
using WebBanHang.Models.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebBanHang.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.AspNet.Identity;
using System;

namespace WebBanHang
{
    public class Startup
    {
        private const string ApiCorsPolicy = "ApiCorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors();
            services.AddDbContext<WebBanHangContext>(options =>
                                         options.UseSqlServer(
                                             Configuration.GetConnectionString("DefaultConnection")
                                         ));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.AccessDeniedPath = new PathString("/Login");
                o.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                o.SlidingExpiration = true;
                o.ExpireTimeSpan = DateTime.Now.AddDays(1).TimeOfDay;
                o.LoginPath = new PathString("/Login");
                o.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                o.SlidingExpiration = true;
            });
            services.AddAuthorization();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            #region Inject Services
            services.AddTransient<ILoginServices, LoginServices>();
            #endregion
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //if (!env.IsDevelopment())
            //{
            //    app.UseHttpsRedirection();
            //}
            // app.UseHttpsRedirection();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"ExportForms")),
            //    RequestPath = new PathString("/ExportForms")
            //});
            app.UseCors(builder =>
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            app.UseRouting();
            // Shows UseCors with CorsPolicyBuilder.
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                // Map the default controllers
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{urlFriendly?}"
                );
                // Map the controllers in the specified area
                endpoints.MapAreaControllerRoute(
                    name: "MyArea",
                    areaName: "Admin", // Replace "Admin" with the name of your area
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{urlFriendly?}"
                );

                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 401 || context.Response.StatusCode == 403)
                {
                    context.Request.Path = "/Login";
                    await next();
                }
            });
        }
    }
}
