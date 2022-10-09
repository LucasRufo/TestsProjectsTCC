using TCC.Alunos.Validators;

namespace TCC.MsTest.Unit;

[TestClass]
public class StudentValidatorTests
{
    public StudentValidator _validator;

    [TestInitialize]
    public void Initialize()
    {
        _validator = new StudentValidator();
    }

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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
