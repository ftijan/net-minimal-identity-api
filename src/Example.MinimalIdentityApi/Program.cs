using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using System;
using Example.MinimalIdentityApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppIdentityContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
	.AddIdentityApiEndpoints<AppIdentityUser>()
	.AddEntityFrameworkStores<AppIdentityContext>();

// Add services to the container.
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

app.MapGroup("/account").MapIdentityApi<AppIdentityUser>();

app.MapGet("/hw", () =>
{	
	return "hello world";
})
.WithName("GetHelloWorld")
.RequireAuthorization()
.WithOpenApi();

app.Run();