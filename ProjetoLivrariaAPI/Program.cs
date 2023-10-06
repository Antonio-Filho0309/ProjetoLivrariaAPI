using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Repositories;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo {
        Version = "1.0",
        Title = "ProjetoLivrariaAPI",
        Description = "Projeto de uma livraria em C#",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact {
            Name = "Antonio José dos Santos Filho",
            Email = "antoniodollmichael@gmail.com",
            Url = new Uri("https://scintillating-biscotti-bbc86f.netlify.app")
        },
        License = new OpenApiLicense {
            Name = "Projeto livraria License",
            Url = new Uri("https://mit.edu")
        },
    });
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    options.IncludeXmlComments(xmlCommentsFullPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
