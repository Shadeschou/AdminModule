using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Qdea.API.Domain;

namespace Qdea.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        IdeaInteractionCreateDto newIdea = new IdeaInteractionCreateDto
        {
            IdeaInteractionID = 1,
            IdeaID = 2,
            IdeaInteractionTypeID = 3,
            UserID = 4,
            Title = "This is awesome Title",
            Description = "This is awesome Title",
            TextContent = "This is awesome Content",
            CreationDate = DateTime.Now,
            LastDateTimeEdited = DateTime.UtcNow
        };
     
    }
}
