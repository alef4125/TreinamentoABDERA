
namespace TarefasBackEndAPI.Modelos;

public class Task
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.Pendente;
    public DateTime DataInicio { get; set; } = DateTime.UtcNow;
}
public enum TaskStatus
{
    Pendente,
    EmAndamento,
    Concluido
}