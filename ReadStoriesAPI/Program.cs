using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadStoriesAPI;
using ReadStoriesAPI.Data;
using ReadStoriesAPI.Repositoy;
using ReadStoriesAPI.Repositoy.IRepository;
using System.Text.Json.Serialization;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddResponseCaching();
//builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));


builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Configure the HTTP request pipeline.
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

app.MapControllers();

app.Run();