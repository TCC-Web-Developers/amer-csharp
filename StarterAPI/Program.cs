using Microsoft.EntityFrameworkCore;
using StarterAPI.Presistence;
using StarterAPI.Interfaces;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IStudentService, IStudentService>();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=./students.db"));

builder.Services.AddTransient<IApplicationDbContext>
    (provider => provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddControllers();
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


