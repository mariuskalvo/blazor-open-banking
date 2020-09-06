using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorBank.BlazorApp.Data;
using BlazorBank.Infrastructure.Proxies;
using BlazorBank.Services.Services;
using BlazorBank.Services.Mappers;
using BlazorBank.Infrastructure.Configuration;
using System.Runtime.CompilerServices;
using BlazorBank.Infrastructure.Utils;
using BlazorBank.BlazorApp.ViewControllers;
using BlazorBank.Services.Models;
using BlazorBank.Infrastructure.Utils.AccessToken;
using LazyCache;

namespace BlazorBank.BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            
            services.AddScoped<WeatherForecastService>();
            services.AddScoped<AccountsViewController>();

            services.AddHttpClient<IAccountProxy, AccountProxy>();
            services.AddHttpClient<ICardProxy, CardProxy>();
            services.AddHttpClient<IAccessTokenProxy, AccessTokenProxy>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICardService, CardService>();

            services.AddSingleton<IHeaderEncoder, SbankenHeaderEncoder>();
            services.AddSingleton<IAccountMapper, AccountMapper>();
            services.AddSingleton<ICardMapper, CardMapper>();

            services.AddSingleton<ICachedTokenProxy, CachedTokenProxy>();
            services.AddSingleton<ITokenCache, TokenCache>();
            services.AddSingleton<IAppCache, CachingService>();

            services.AddSingleton(new CustomerConfiguration
            {
                CustomerId = Configuration["CustomerId"]
            });

            services.AddSingleton<IApiClientConfiguration>(new SbankenApiConfiguration
            {
                ClientId = Configuration["ClientId"],
                ClientSecret = Configuration["ClientSecret"]
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
