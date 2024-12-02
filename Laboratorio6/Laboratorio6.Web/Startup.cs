using Laboratorio6.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Laboratorio6.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Microsoft.AspNetCore.Hosting.IWebHostEnvironment Env { get; set; }

        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            Env = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvc();

#if DEBUG
            builder.AddRazorRuntimeCompilation();
#endif

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Features/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/Shared/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();

            app.UseRouting();

            var node_modules = new CompositePhysicalFileProvider(Directory.GetCurrentDirectory(), "node_modules");
            var features = new CompositePhysicalFileProvider(Directory.GetCurrentDirectory(), "Features");
            var compositeFp = new CustomCompositeFileProvider(env.WebRootFileProvider, node_modules, features);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = compositeFp
            });
            env.WebRootFileProvider = compositeFp;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Esercizio}/{action=Index}");
            });
        }
    }
}
