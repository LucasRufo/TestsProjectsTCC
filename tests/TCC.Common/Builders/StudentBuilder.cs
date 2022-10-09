using Bogus;
using TCC.Alunos;

namespace TCC.Common.Builders;

public class StudentBuilder : Faker<Student>
{
    public StudentBuilder()
    {
        RuleFor(m => m.Id, faker => faker.Random.Guid());
        RuleFor(m => m.Name, faker => faker.Random.String2(100));
        RuleFor(m => m.Age, faker => faker.Random.Number(18, 80));
        RuleFor(m => m.Classes, faker => faker.Make(3, () => faker.Random.String2(100)));
        RuleFor(m => m.CreatedAt, faker => faker.Date.Past());
        RuleFor(m => m.UpdatedAt, faker => faker.Date.Past());
    }

    public StudentBuilder WithId(Guid id)
    {
        RuleFor(m => m.Id, () => id);
        return this;
    }

    public StudentBuilder WithName(string? name)
    {
        RuleFor(m => m.Name, () => name);
        return this;
    }

    public StudentBuilder WithAge(int age)
    {
        RuleFor(m => m.Age, () => age);
        return this;
    }

    public StudentBuilder WithClasses(List<string>? classes)
    {
        RuleFor(m => m.Classes, () => classes);
        return this;
    }
}
