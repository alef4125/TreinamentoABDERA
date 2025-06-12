
namespace Application.Models;


public class TaskItem  
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } 
    public DateTime DataInicio { get; set; } = DateTime.UtcNow;
}
