using BooksLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
                        option.AddPolicy("Allow all", 
                        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
                        );

builder.Services.AddSingleton<BooksRepository>(new BooksRepository());

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "XXXX API v1.0");
    c.RoutePrefix = "api/help";
});

app.UseAuthorization();

app.UseCors("Allow all");

app.MapControllers();

app.Run();
