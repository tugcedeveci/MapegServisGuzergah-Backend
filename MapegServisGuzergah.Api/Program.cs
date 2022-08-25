using MapegServisGuzergah.Dal.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using MapegServisGuzergah.Bll;
using MapegServisGuzergah.Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

var connectionString = builder.Configuration.GetConnectionString("prod");
builder.Services.AddDbContext<EntityFrameworkDbContext>(x => x.UseNpgsql(connectionString, options => options.UseNetTopologySuite().MigrationsAssembly("MapegServisGuzergah.Dal")));

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.IoCDataAccessLayerRegister();
builder.Services.IoCBusinessLayerRegister();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
