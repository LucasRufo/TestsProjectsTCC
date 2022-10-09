using TCC.Alunos.Validators;

namespace TCC.XUnit.Unit;

public abstract class BaseUnitTests
{
    protected StudentValidator _validator;

    protected BaseUnitTests()
    {
        _validator = new StudentValidator();
    }
}
