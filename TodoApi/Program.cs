using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
// clonando um novo repositorio no GitHub
// Fazendo novamente o push para o GitHub
// Fazendo novamente o pull para o Visual Studio
// Dar merge no código
namespace TodoApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar um Builder de uma Web Application (Web Application é complexa -> Então usados o padrão
            //  Builder)
            var builder = WebApplication.CreateBuilder();

            // Configurar serviços (Injeção de Dependência)
            builder.Services.AddControllers();

            // Constroi a aplicação (builder.Build())
            var app = builder.Build();

            app.MapControllers();

            // Roda aplicação
            app.Run();
        }
    }
}
