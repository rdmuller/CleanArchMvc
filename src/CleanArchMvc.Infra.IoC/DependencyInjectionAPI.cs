using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Security;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvc.Infra.Data.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjectionAPI
{
    public static void AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        AddIdentity(services, configuration);
        AddRepositories(services);
        AddServices(services);

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));
    }

    private static void AddIdentity(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthenticate, AuthenticateService>();

        var signingKey = configuration.GetValue<string>("Jwt:SecretKey")!;
        var audience = configuration.GetValue<string>("Jwt:Audience")!;
        var issuer = configuration.GetValue<string>("Jwt:Issuer")!;

        services.AddScoped<IAccessTokenGenerator, AccessTokenGenerator>(config => new AccessTokenGenerator(
            expirationTimeMinutes: 240,
            signingKey: signingKey,
            audience: audience,
            issuer: issuer
        ));
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
        );

        //var connectionString = configuration.GetConnectionString("Connection");  // para ler do appsettings "Server=localhost;Database=cashflow;Uid=root;Pwd=docker";
        //var serverVersion = ServerVersion.AutoDetect(connectionString);

        //services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));

    }

}
