using Microsoft.EntityFrameworkCore;
using TarefasBackEnd.Application.Handlers;
using TarefasBackEndAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=tarefas.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/tarefas", TaskHandler.CreateTask);
app.MapGet("/tarefas", TaskHandler.GetTasks);
app.MapGet("/tarefas/{id}", TaskHandler.GetTaskById);
app.MapPut("/tarefas/{id}/status", TaskHandler.UpdateStatus);
app.MapDelete("/tarefas/{id}", TaskHandler.DeleteTask);

app.Run();