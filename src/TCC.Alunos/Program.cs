using TCC.Alunos;
using TCC.Alunos.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var db = new { Students = new List<Student>() };

app.MapGet("/students", () => 
{
    return Results.Ok(db.Students);
});

app.MapGet("/students/{id}", (Guid id) =>
{
    var student = db.Students.FirstOrDefault(m => m.Id == id);

    if(student is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(student);
});

app.MapPost("/students", (Student student) => 
{
    var validator = new StudentValidator();
    var validationResult = validator.Validate(student);

    if(!validationResult.IsValid)
    {
        return Results.BadRequest(validationResult.Errors);
    }

    student.Id = Guid.NewGuid();
    student.CreatedAt = DateTime.Now;

    db.Students.Add(student);

    return Results.Created($"/students/{student.Id}", student);
});

app.MapPut("/students/{id}", (Guid id, Student student) =>
{
    var existingStudent = db.Students.FirstOrDefault(m => m.Id == id);

    if (existingStudent is null)
    {
        return Results.NotFound();
    }

    var validator = new StudentValidator();
    var validationResult = validator.Validate(student);

    if (!validationResult.IsValid)
    {
        return Results.BadRequest(validationResult.Errors);
    }

    existingStudent.Name = student.Name;
    existingStudent.Age = student.Age;
    existingStudent.Classes = student.Classes;
    existingStudent.UpdatedAt = DateTime.Now;

    return Results.Ok(existingStudent);
});

app.MapDelete("/students/{id}", (Guid id) =>
{
    var existingStudent = db.Students.FirstOrDefault(m => m.Id == id);

    if (existingStudent is null)
    {
        return Results.NotFound();
    }

    db.Students.RemoveAll(m => m.Id == id);

    return Results.Ok(existingStudent);
});

app.Run();

public partial class Program { }
