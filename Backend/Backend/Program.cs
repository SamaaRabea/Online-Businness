using Microsoft.EntityFrameworkCore;
using Shope.BL;
using Shope.DAL;

var builder = WebApplication.CreateBuilder(args);

#region core
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
#endregion

// Add services to the container.
#region Services

#region Default
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Database
var connectionString = builder.Configuration.GetConnectionString("ShopeDb");
builder.Services.AddDbContext<ShopeContext>(options => options.UseSqlServer(connectionString));
#endregion

#region Repo
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

#endregion

#region Managers

builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICategoriesManagers, CategoriesManagers>();

#endregion

#endregion
var app = builder.Build();

#region Middlware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion

