using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<ProductDataContext>("productsdb");

// Add services to the container.
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.MapProductEndpoints();

app.UseStaticFiles();

app.CreateDbIfNotExists();

app.Run();
