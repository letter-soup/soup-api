using Auth.Wiedersehen.Controllers.Services;
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

    protected ILocalizer<T> SetupLocalizer<T>()
    {
        var localizerMock = new Mock<ILocalizer<T>>();
        localizerMock.Setup(x => x.GetString(It.IsAny<string>())).Returns((string key) => key);
        localizerMock.Setup(x => x.GetString(It.IsAny<string>(), It.IsAny<object[]>())).Returns((string key, object[] _) => key);
        
        return localizerMock.Object;
    }
}