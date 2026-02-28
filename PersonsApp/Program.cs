using Microsoft.AspNetCore.Builder; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting; 
using PersonsApp.Database;
using Scalar.AspNetCore;

var builder=WebApplication.CreateBuilder(args); 

builder.Services.AddDbContext<PersonsDbContext>(options=>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi(); 

builder.Services.AddControllers(); 
var app = builder.Build();  //CONSTRUCCIÓN DE LA APP


if (app.Environment.IsDevelopment()) 
{
    app.MapOpenApi();  
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection(); 
app.UseAuthorization(); 

app.MapControllers(); //Todas las clases que terminen con Controller se mapean automáticamente

app.Run(); // Inicia la aplicación web














// using Scalar.AspNetCore;

// var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddOpenApi();

// builder.Services.AddControllers();

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
//     app.MapScalarApiReference();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers(); 