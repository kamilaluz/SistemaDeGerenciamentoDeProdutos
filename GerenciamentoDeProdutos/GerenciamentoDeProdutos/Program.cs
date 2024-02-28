using GerenciamentoDeProdutos;
using GerenciamentoDeProdutos.Middlewares;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Add Services to PostgreSQL
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql
        (builder.Configuration.GetConnectionString("DefaultConnection")));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
       
        app.UseAuthorization();

        // Utilizando o Middleware de exceção
        app.UseMiddleware(typeof(ErrorHandingMiddleware));

        app.MapControllers();

        app.Run();
    }
}