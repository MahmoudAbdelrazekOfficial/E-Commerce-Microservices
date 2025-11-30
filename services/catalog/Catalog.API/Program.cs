var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Catalog API",
        Version = "v1",
        Description = "This API for catalog microservices in my application",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Mahmoud Abdelrazek",
            Email = "Mahmoudabdelrazekofficial@gmail.com",
            Url = new Uri (" https://github.com/MahmoudAbdelrazekOfficial")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "Catalog API v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
