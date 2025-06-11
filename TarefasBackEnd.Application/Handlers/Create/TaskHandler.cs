using Microsoft.EntityFrameworkCore;
using TarefasBackEndAPI.Data;
using TarefasBackEndAPI.DTOs;
using TarefasBackEndAPI.Modelos;
using TaskStatus = TarefasBackEndAPI.Modelos.TaskStatus;


namespace Application.Handlers.Create;

public static class TaskHandler
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
        return Results.Created($"/tarefas/{task.Id}", new TaskRealDto
        {
            Id = task.Id,
            Titulo = task.Titulo,
            Descricao = task.Descricao,
            Status = task.Status.ToString(),
            DataInicio = task.DataInicio
        });
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

    public static async Task<IResult> GetTaskById(int id, AppDbContext db)
    {
        var tarefa = await db.Tarefas.FindAsync(id);
        return tarefa is null ? Results.NotFound() : Results.Ok(tarefa);
    }

    public static async Task<IResult> UpdateStatus(int id, TaskUpdateStatusDto dto, AppDbContext db)
    {
        var tarefa = await db.Tarefas.FindAsync(id);
        if (tarefa is null) return Results.NotFound();
        
        if (!Enum.TryParse<TaskStatus>(dto.Status, true, out var status))
            return Results.BadRequest("Status invalido, Valores permitidos" + string.Join(",", Enum.GetNames(typeof(TaskStatus))));
        
        tarefa.Status = status;
        await db.SaveChangesAsync();
        
        return Results.Ok(new TaskRealDto
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Status = tarefa.Status.ToString(),
            DataInicio = tarefa.DataInicio
        });
        
    }
    
    public static async Task<IResult> DeleteTask(int id, AppDbContext db)
    {
        var tarefa = await db.Tarefas.FindAsync(id);
        if (tarefa is null)
            return Results.NotFound("Tarefa não encontrada.");

        db.Tarefas.Remove(tarefa);
        await db.SaveChangesAsync();
    
        return Results.NoContent();
    }

}