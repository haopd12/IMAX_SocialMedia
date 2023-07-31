using App.Shared.AppSession;
using UserLog.IOC;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.Register();
builder.Services.AddDbContext(configuration);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.RegisterDependencyBase();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpAppSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();