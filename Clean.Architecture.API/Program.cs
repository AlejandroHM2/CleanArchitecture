using Clean.Architecture.Entities.Exceptions;
using Clean.Architecture.IoC;
using Clean.Architecture.WebExceptionsPresenter;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ApiExceptionFilterAttribute(
        new Dictionary<Type, IExceptionHandler>
        {
            { typeof(GeneralException), new GeneralExceptionHandler() },
            { typeof(ValidationException), new ValidationExceptionHandler() },
        }));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCleanArchitectureServices(builder.Configuration);

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

app.Run();
