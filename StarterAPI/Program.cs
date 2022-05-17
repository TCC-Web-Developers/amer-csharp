using Microsoft.EntityFrameworkCore;
using StarterAPI.Presistence;
using StarterAPI.Interfaces;
using StarterAPI.Services;
using StarterAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=./students.db"));

builder.Services.AddScoped<IApplicationDbContext>
    (provider => provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddCors();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DI
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IClassService, ClassService>();

var app = builder.Build();

// Migrate any database changes on startup
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

// Global Error Handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();


