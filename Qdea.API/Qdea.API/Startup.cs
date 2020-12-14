using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qdea.API.Data;
using Qdea.API.Models;
using System;

namespace Qdea.API
{
    public class Startup
    {
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("QdeaConnection")));

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            ConfigureScoped(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureScoped(IServiceCollection service)
        {
            service.AddScoped<IIdea, IdeasAccess>();
            service.AddScoped<IIdeaStatus, IdeaStatusAccess>();
            service.AddScoped<IPriority, PrioritiesAccess>();
            service.AddScoped<ITagIdea, TagIdeasAccess>();
            service.AddScoped<ITag, TagsAccess>();
            service.AddScoped<IUser, UsersAccess>();
            service.AddScoped<IUserStatus, UserStatusesAccess>();
            service.AddScoped<IIdeaInteraction, IdeaInteractionsAccess>();
            service.AddScoped<IIdeaInteractionType, IdeaInteractionTypesAccess>();
        }
    }
}
