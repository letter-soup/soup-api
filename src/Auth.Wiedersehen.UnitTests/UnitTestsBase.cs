using Microsoft.Extensions.Configuration;
using Moq;

namespace Auth.Wiedersehen.UnitTests;

public class UnitTestsBase
{
    protected readonly IConfiguration Configuration;
    protected readonly IFixture Fixture;
    
    private const int PasswordMinLength = 8;

    protected UnitTestsBase()
    {
        var configMock = new Mock<IConfiguration>();
        
        var passwordMinLength = new Mock<IConfigurationSection>();
        passwordMinLength.Setup(x => x.Value).Returns(PasswordMinLength.ToString());
        configMock.Setup(x => x.GetSection("Password:MinLength")).Returns(passwordMinLength.Object);
        
        Configuration = configMock.Object;
        Fixture = new Fixture();
    }
}