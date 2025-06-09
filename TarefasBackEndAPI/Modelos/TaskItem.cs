
namespace TarefasBackEndAPI.Modelos;

public enum TaskStatus
{
    Pendente,
    EmAndamento,
    Concluido
}
public class TaskItem
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.Pendente;
    public DateTime DataInicio { get; set; } = DateTime.UtcNow;
}
