using Microsoft.EntityFrameworkCore;
using MovieService.Data;
using MovieService.Data.ActorData;
using MovieService.Data.CategoryData;
using MovieService.Data.MovieData;
using MovieService.Data.MovieTypeData;
using MovieService.Data.Producer;
using MovieService.Service;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Thêm các dịch vụ vào container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Đăng ký dịch vụ scoped
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMovieTypeRepository, MovieTypeRepository>();

// Đăng ký auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Đăng ký dịch vụ hosted với factory
builder.Services.AddSingleton<MovieService>();
builder.Services.AddSingleton<IHostedService>(provider => provider.GetRequiredService<MovieService>());

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5002") // Cập nhật URL này để khớp với URL của ứng dụng React của bạn
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Cấu hình pipeline yêu cầu HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
