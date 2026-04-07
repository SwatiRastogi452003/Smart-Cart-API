
using SmartCart.Api.Repositories;
using SmartCart.Api.Services;
 
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddSingleton<CartRepository>();
builder.Services.AddSingleton<CartService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
 
    app.UseSwagger();
    app.UseSwaggerUI();
 


app.MapControllers();
app.Run();
