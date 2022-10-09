namespace TCC.Alunos;

public record Student
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public List<string>? Classes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}