using Microsoft.EntityFrameworkCore;
using Stocky.Business.Contracts;
using Stocky.Business.Impls;
using Stocky.Data;
using Stocky.Zynerator.Business.Contracts;
using Stocky.Zynerator.Business.Impls;

var builder = WebApplication.CreateBuilder(args);
string allowSpecificOrigins = "_allowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Replace with the actual origin of your Angular app
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ClientAdminService, ClientAdminServiceImpl>();
builder.Services.AddScoped<ProduitAdminService, ProduitAdminServiceImpl>();
builder.Services.AddScoped<AchatAdminService, AchatAdminServiceImpl>();
builder.Services.AddScoped<AchatItemAdminService, AchatItemAdminServiceImpl>();
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

app.UseCors("AllowSpecificOrigin");

app.Run();
