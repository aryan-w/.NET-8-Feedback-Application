using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DonationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
);

builder.Services.AddCors();


var app = builder.Build();

app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
