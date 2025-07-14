using Microsoft.EntityFrameworkCore;
using Application.Mappers;
using Application.Queries.Handlers;
using Infrastructure.Contexts;
using Infrastructure.Services;
using Application.Interfaces.Services;
using Application.Interfaces.Repositories;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Application.Commands.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AnimeProfile));

builder.Services.AddScoped<IAnimeService, AnimeService>();

builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
})
.AddMvc() 
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAnimesHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateAnimeHandler).Assembly);
});

// Add DbContext
builder.Services.AddDbContext<AnimesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AnimesDbContext>();
    dbContext.Database.Migrate(); // Vai aplicar migrations, incluindo criar banco se não existir
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
