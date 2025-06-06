using Microsoft.EntityFrameworkCore;
using TarefasBackEndAPI.Data;
using TarefasBackEndAPI.DTOs;
using TarefasBackEndAPI.Modelos;

namespace TarefasBackEndAPI.Handlers;

public static class TaskHandlers
{
    public static async Task<IResult> CreateTask(TaskCreateDto dto, AppDbContext db)
    {
        var task = new TaskItem
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
        };

        db.Tarefas.Add(task);
        await db.SaveChangesAsync();
        return Results.Created($"/tarefas/{task.Id}", task);
    }

    public static async Task<IResult> GetTasks(AppDbContext db, int page = 1, int pageSize = 10)
    {
        var tarefas = await db.Tarefas
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new TaskRealDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                Status = t.Status.ToString(),
                DataInicio = t.DataInicio
            })
            .ToListAsync();
        
        return Results.Ok(tarefas);
    }
    
    public static async 
}