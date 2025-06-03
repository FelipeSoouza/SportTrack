using WebSport.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<MongoService<WebSport.Models.Feedback>>(sp =>
    new MongoService<WebSport.Models.Feedback>(builder.Configuration, "Feedbacks"));

builder.Services.AddSingleton<MongoService<WebSport.Models.User>>(sp =>
    new MongoService<WebSport.Models.User>(builder.Configuration, "Users"));

builder.Services.AddSingleton<MongoService<WebSport.Models.Training>>(sp =>
    new MongoService<WebSport.Models.Training>(builder.Configuration, "Trainings"));

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
