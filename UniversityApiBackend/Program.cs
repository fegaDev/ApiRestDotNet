// 1. Using to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

//2. Create Connexion

const string ConnectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(ConnectionName);

//3. Add Context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));



//7. Add Services of JWT AUTORIZATION
// builder.Services.addJwtTokenServices(builder.Configuration);



// Add services to the container.

builder.Services.AddControllers();

//4. Add Custom Services (folder Services)

builder.Services.AddScoped<IStudentsService, StudentsService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//8. TODO: CONFIG SWAGGER TO TAKE CARE OF AUTORIZATION OF JWT
builder.Services.AddSwaggerGen();


//5. CORS : CONFIGURATION
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
}
);


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

//6. Use Cors o Enable Cors
app.UseCors("CorsPolicy");

app.Run();
