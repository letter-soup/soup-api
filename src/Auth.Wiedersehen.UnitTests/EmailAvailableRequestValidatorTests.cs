using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.UnitTests.Extensions;
using FluentValidation.TestHelper;

namespace Auth.Wiedersehen.UnitTests;

public class EmailAvailableRequestValidatorTests : UnitTestsBase
{
    private readonly EmailAvailableRequestValidator _validator = new();

    [Fact]
    public void GivenEmptyEmail_ShouldHaveError()
    {
        var model = new EmailAvailableRequest(string.Empty);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void GivenInvalidEmail_ShouldHaveError()
    {
        var model = new EmailAvailableRequest(Fixture.Create<string>());
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void GivenValidEmail_ShouldNotHaveError()
    {
        var model = new EmailAvailableRequest(Fixture.CreateEmail());
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
