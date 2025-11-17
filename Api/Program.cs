using Application.Apartments.Queries;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register MediatR handlers
builder.Services.AddMediatR(cfg =>
{
    // Provide the assembly that contains your handlers
    cfg.RegisterServicesFromAssembly(typeof(GetAllApartmentsQuery).Assembly);
});

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Application & Infrastructure
//builder.Services.AddMediatR(typeof(GetAllApartmentsQuery).Assembly);
//builder.Services.AddValidatorsFromAssembly(typeof(CreateApartmentValidator).Assembly);
//builder.Services.AddInfrastructure(builder.Configuration);

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
