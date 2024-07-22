using NguyenHung.Api.Extensions;
using NguyenHung.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.RegisterService();
builder.Services.AddCors(options => options.AddPolicy("NguyenHungClient", policyBuilder =>
{
    policyBuilder.WithOrigins("http://localhost:3000");
    policyBuilder.AllowAnyHeader();
    policyBuilder.AllowAnyMethod();
    policyBuilder.AllowCredentials();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseCors("NguyenHungClient");
app.EnsureMigrations();
app.Run();

