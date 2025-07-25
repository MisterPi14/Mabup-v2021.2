﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mabup2_Beta
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink(); // ← Agregado
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                //pattern: "{controller=Gestor_Tareas}/{action=Gestor}/{id?}");
                pattern: "{controller=LogIn_y_Registro}/{action=LogIn}/{id?}");
                //pattern: "{controller=LogIn_y_Registro}/{action=Ventana_Principal}/{id?}");
                //pattern: "{controller=Servicio_Stream}/{action=Panel_Materias}/{id?}");
                //pattern: "{controller=Foro_de_discusion}/{action=Buscar_Foro}/{id?}");
                //pattern: "{controller=Foro_de_discusion}/{action=Foro}/{id?}");

            });
        }
    }
}
