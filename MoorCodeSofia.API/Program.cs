using MoorCodeSofia.API.Configurations;
using Serilog;

namespace MoorCodeSofia.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .InstallServices(
                    builder.Configuration,
                    typeof(IServiceInstaller).Assembly);

            builder.Host.UseSerilog((context, configuration) =>
                configuration
                    //.WriteTo.Console()
                    //.MinimumLevel.Information());
                    .ReadFrom.Configuration(context.Configuration));


            //builder.Services
            //    .AddDbContext<ApplicationDbContext>(options =>
            //        options.UseInMemoryDatabase(databaseName: "testdb"));



            builder.Services.AddControllers();



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}