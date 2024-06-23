using Microsoft.EntityFrameworkCore;
using PractiseScratch.DbContext;
using PractiseScratch.Repositories;
using PractiseScratch.Repositories.Interfaces;
using PractiseScratch.Services;
using PractiseScratch.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IActorMovieRepository, ActorMovieRepository>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();

//Add this 1st
builder.Services.AddControllers();
builder.Services.AddDbContext<CinemaContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

