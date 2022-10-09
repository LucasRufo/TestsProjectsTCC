using TCC.Alunos.Validators;

namespace TCC.NUnit.Unit;

public class StudentValidatorTests
{
    public StudentValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new StudentValidator();
    }

    [Test]
    public void ShouldRequireName()
    {
        //arrange
        var fakeStudent = new StudentBuilder()
            .WithName(null)
            .Generate();

        //act
        var validationResults = _validator.Validate(fakeStudent);

        //assert
        validationResults.IsValid.Should().BeFalse();
    }

    [Test]
    public void ShouldNotPermitNameWithMoreThan100Characters()
    {
        //arrange
        var fakeStudent = new StudentBuilder()
            .WithName(new string('a', 101))
            .Generate();

        //act
        var validationResults = _validator.Validate(fakeStudent);

        //assert
        validationResults.IsValid.Should().BeFalse();
    }

    [Test]
    public void ShouldNotPermitAgeLessThan18()
    {
        //arrange
        var fakeStudent = new StudentBuilder()
            .WithAge(16)
            .Generate();

        //act
        var validationResults = _validator.Validate(fakeStudent);

        //assert
        validationResults.IsValid.Should().BeFalse();
    }

    [Test]
    public void ShouldNotPermitAgeGreaterThan80()
    {
        //arrange
        var fakeStudent = new StudentBuilder()
            .WithAge(90)
            .Generate();

        //act
        var validationResults = _validator.Validate(fakeStudent);

        //assert
        validationResults.IsValid.Should().BeFalse();
    }

    [Test]
    public void ShouldRequireClasses()
    {
        //arrange
        var fakeStudent = new StudentBuilder()
            .WithClasses(null)
            .Generate();

        //act
        var validationResults = _validator.Validate(fakeStudent);

        //assert
        validationResults.IsValid.Should().BeFalse();
    }

    [Test]
    public void ShouldRequireClassesNames()
    {
        //arrange
        var fakeStudent = new StudentBuilder()
            .WithClasses(new List<string>() { "" })
            .Generate();

        //act
        var validationResults = _validator.Validate(fakeStudent);

        //assert
        validationResults.IsValid.Should().BeFalse();
    }

    [Test]
    public void ShouldNotPermitClassNameWithMoreThan100Characters()
    {
        //arrange
        var fakeStudent = new StudentBuilder()
            .WithClasses(new List<string>() { new string('c', 101) })
            .Generate();

        //act
        var validationResults = _validator.Validate(fakeStudent);

        //assert
        validationResults.IsValid.Should().BeFalse();
    }
}
