using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Chirper;

public static class ConfigureServices
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.AddServiceDefaults();
        builder.Services.AddProblemDetails();
        builder.AddDatabasae();
        builder.AddSerilog();
        builder.AddSwagger();
        builder.Services.AddValidatorsFromAssembly(typeof(ConfigureServices).Assembly);
    }
    private static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<PostDbContext>(connectionName: "postdb");
    }
    private static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
            options.InferSecuritySchemes();
        });
    }

    private static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });
    }


}