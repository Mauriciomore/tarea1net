using LiteThinkingProject.Shared.Core;
using LiteThinkingProject.Application;
using LiteThinkingProject.Infraestructure;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddSwaggerGen();

var app = builder.Build();

EngineContext.Current.Configure(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
