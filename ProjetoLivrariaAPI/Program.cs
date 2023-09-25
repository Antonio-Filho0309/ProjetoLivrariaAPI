using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IRepository, Repository>();

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
