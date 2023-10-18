using Microsoft.EntityFrameworkCore;
using WebAPITest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(cors => cors.AddPolicy("all", option => {
    option.AllowAnyOrigin();
    option.AllowAnyMethod();
    option.AllowAnyHeader();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastReport();   
builder.Services.AddSingleton(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),"People.frx"));
builder.Services.AddEntityFrameworkNpgsql();
var connection = builder.Configuration.GetConnectionString("DB");
builder.Services.AddDbContext<ContextDatabase>(e =>
e.UseNpgsql(connection));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("all");
app.UseHttpsRedirection();
app.UseFastReport();

app.UseAuthorization();

app.MapControllers();

app.Run();
