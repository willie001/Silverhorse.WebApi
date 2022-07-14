using Microsoft.AspNetCore.Authentication;
using Silverhorse.WebApi.CustomAuthentication;
using Silverhorse.WebApi.SwaggerConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<HeaderFilter>();
});

// Add Custom Authentication
builder.Services.AddAuthentication("BearerAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BearerAuthenticationHandler>
    ("BearerAuthentication", null);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
