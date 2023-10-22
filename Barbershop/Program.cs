using Microsoft.EntityFrameworkCore;
using barbershopApi.Data; // Add this using statement to access your context
using Microsoft.OpenApi.Models; // Add this using statement for Swagger/OpenAPI
using barbershopApi.Services;
using barbershopApi.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Enable CORS
builder.Services.AddCors();

// Configure DbContext
builder.Services.AddDbContext<BarberShopContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Register your services for dependency injection
builder.Services.AddTransient<IBarberService, BarberService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IBarberRepository, BarberRepository>();
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
// Register other services and dependencies as needed


builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
