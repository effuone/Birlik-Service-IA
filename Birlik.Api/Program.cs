using Birlik.Api.Preparations;
using Birlik.Core.Interfaces;
using Birlik.Core.Repositories;
using Birlik.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var server = builder.Configuration["DB_SERVER"];
var port = builder.Configuration["DB_PORT"];
var user = builder.Configuration["DB_USER"];
var password = builder.Configuration["DB_PASSWORD"];
var database = builder.Configuration["DB_DATABASE"];
var connectionString = $"Server=tcp:{server}, {port};Database={database};User Id={user};Password={password}";   
// var connectionString = $"Server=tcp:{server}, {port};Database={database};User Id={user};Password={password}";
builder.Services.AddDbContext<BirlikDbContext>(options=>options.UseSqlServer(connectionString));

//AutoMapper configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependency Injection
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddSwaggerGen();


//supressing async suffix in action names for retrieving object via "CreatedAtAction" method after HttpPost requests
builder.Services.AddMvc(options =>
{
   options.SuppressAsyncSuffixInActionNames = false;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
app.MapControllers();

MigrationImplementer.PrepPopulation(app);

app.Run();
