using Microsoft.EntityFrameworkCore;
using P1_AgendamentoMédico.Repositories;
using P1_AgendamentoMédico.Services;

namespace P1_AgendamentoMédico
{
    public class Program
    {

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AgendamentoMedicoDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void AddControllersAndDependencies(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            // Injeção de dependências
            builder.Services.AddScoped<AgendamentoService>();
            builder.Services.AddScoped<MedicoService>();
            builder.Services.AddScoped<PacienteService>();

            builder.Services.AddScoped<MedicoRepository>();
            builder.Services.AddScoped<PacienteRepository>();
            builder.Services.AddScoped<AgendamentoRepository>();
        }

        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);
            AddControllersAndDependencies(builder);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Inicialização do Swagger
                InitializeSwagger(app);
            }

            app.MapControllers();

            app.Run();
        }
    }
}
