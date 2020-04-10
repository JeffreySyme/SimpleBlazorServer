using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using SimpleBlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using SimpleBlazorServer.Queries;
using SimpleBlazorServer.Commands;
using AutoMapper;
using MediatR;
using FluentValidation;
using SimpleBlazorServer.Web.Extensions;
using SimpleBlazorServer.Web.Behaviors;

namespace SimpleBlazorServer.Web
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

            services.AddBlazorise(options => options.ChangeTextOnKeyPress = true)
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AppDatabase")), ServiceLifetime.Transient);

            services.AddAutoMapper(
                typeof(QueryRegistry),
                typeof(CommandRegistry));

            services.AddMediatR(
                config => config.AsTransient(),
                typeof(QueryRegistry),
                typeof(CommandRegistry));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthenticationBehavior<,>));

            services.AddValidatorsFromAssemblyContaining<QueryRegistry>();
            services.AddValidatorsFromAssemblyContaining<CommandRegistry>();

            services.AddCustomServices();
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

            app.ApplicationServices
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
