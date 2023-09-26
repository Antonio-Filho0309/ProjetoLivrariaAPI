using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Data.Intefaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
