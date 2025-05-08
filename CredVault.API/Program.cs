using Microsoft.EntityFrameworkCore;
using CredVault.API.Data;
using CredVault.API.Repositories;
using CredVault.API.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CredVaultDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CredVaultConnectionString"))); // Registers EF Core DbContext as a service, so it can be injected where needed (like in controllers).

// Inject the IUserRepository with the UserRepository implementation
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICredentialRepository, CredentialRepository>();

// Inject Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
