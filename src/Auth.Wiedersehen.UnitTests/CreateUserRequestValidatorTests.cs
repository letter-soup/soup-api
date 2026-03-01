using Auth.Wiedersehen.Controllers.Models;
using Auth.Wiedersehen.UnitTests.Extensions;
using FluentValidation.TestHelper;
using Microsoft.Extensions.Configuration;

namespace Auth.Wiedersehen.UnitTests;

public class CreateUserRequestValidatorTests : UnitTestsBase
{
    private readonly CreateUserRequestValidator _validator;
    
    public CreateUserRequestValidatorTests()
    {
        _validator = new CreateUserRequestValidator(Configuration);
    }

    [Fact]
    public void GivenEmptyEmail_ShouldHaveError()
    {
        var model = new CreateUserRequest(string.Empty, Fixture.CreatePassword(), true);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void GivenInvalidEmail_ShouldHaveError()
    {
        var model = new CreateUserRequest(Fixture.Create<string>(), Fixture.CreatePassword(), true);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void GivenEmptyPassword_ShouldHaveError()
    {
        var model = new CreateUserRequest(Fixture.CreateEmail(), string.Empty, true);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void GivenShortPassword_ShouldHaveError()
    {
        var passwordLength = Configuration.GetValue<int>("Password:MinLength") - 1;
        var model = new CreateUserRequest(
            Fixture.CreateEmail(),
            Fixture.CreatePassword(length: passwordLength),
            true
        );
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void GivenPasswordWithoutUppercase_ShouldHaveError()
    {
        var model = new CreateUserRequest(
            Fixture.CreateEmail(),
            Fixture.CreatePassword(config: PasswordConfig.All & ~PasswordConfig.UpperCase),
            true
        );
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void GivenPasswordWithoutLowercase_ShouldHaveError()
    {
        var model = new CreateUserRequest(
            Fixture.CreateEmail(),
            Fixture.CreatePassword(config: PasswordConfig.All & ~PasswordConfig.LowerCase),
            true
        );
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void GivenPasswordWithoutDigit_ShouldHaveError()
    {
        var model = new CreateUserRequest(
            Fixture.CreateEmail(),
            Fixture.CreatePassword(config: PasswordConfig.All & ~PasswordConfig.Digits),
            true
        );
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void GivenPasswordWithoutSpecialCharacter_ShouldHaveError()
    {
        var model = new CreateUserRequest(
            Fixture.CreateEmail(), 
            Fixture.CreatePassword(config: PasswordConfig.All & ~PasswordConfig.Special), 
            true
        );
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void GivenTermsNotAccepted_ShouldHaveError()
    {
        var model = new CreateUserRequest(Fixture.CreateEmail(), Fixture.CreatePassword(), false);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.TermsAccepted);
    }

    [Fact]
    public void GivenValidRequest_ShouldHaveNoError()
    {
        var model = new CreateUserRequest(Fixture.CreateEmail(), Fixture.CreatePassword(), true);
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
