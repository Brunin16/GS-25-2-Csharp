using Business;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICompetenciaService, CompetenciaService>();
builder.Services.AddScoped<ITrilhaCompetenciaService, TrilhaCompetenciaService>();
builder.Services.AddScoped<ITrilhaCompetenciaService, TrilhaCompetenciaService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();

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
