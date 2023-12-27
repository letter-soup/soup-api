using Microsoft.AspNetCore.Mvc;
using Soup.Api.Extensions;

namespace Soup.Api.Controllers;

[Controller]
public class TestController(IConfiguration configuration) : Controller
{
    private readonly IConfiguration _configuration = configuration.Required(nameof(configuration));

    [HttpGet, Route("api/test")]
    public IActionResult Test()
    {
        return Ok("Hello world: " + _configuration["AllowedHosts"]);
    }
}