using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Profiles;
using BlogApp.Business.Services.Implimentations;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Implimentations;
using BlogApp.DAL.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryRepository,CategoryRepository> ();
builder.Services.AddScoped<ICategoryservice,CategoryService> ();
builder.Services.AddControllers().AddFluentValidation(opt=>
{
    opt.RegisterValidatorsFromAssembly(typeof(CategoryCreateDtoValidation).Assembly);
});
builder.Services.AddAutoMapper(typeof(CategoryMapProfile).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
