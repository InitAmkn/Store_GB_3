
using Microsoft.EntityFrameworkCore;
using Store_GB_3;
using Store_GB_3.Abstractions;
using Store_GB_3.Mapper;
using Store_GB_3.Query;
using Store_GB_3.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //builder.Services.AddDbContext<AppDbContext>(options =>
        //{
        //    options.UseNpgsql(builder.Configuration.GetConnectionString("db"));
        //});
        builder.Configuration.GetConnectionString("db");
        builder.Services.AddMemoryCache();
        builder.Services.AddAutoMapper(typeof(MapperProfile));

        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IStorageService, StorageService>();
        builder.Services.AddTransient<ICategoryService, CategoryService>();


        builder.Services.AddTransient<AppDbContext>();

        builder.Services
            .AddGraphQLServer()
            .AddQueryType<MyQuery>();

        

        var app = builder.Build();
        app.MapGraphQL();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        app.Run();
    }
}