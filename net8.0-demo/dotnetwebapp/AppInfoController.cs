using Microsoft.AspNetCore.Mvc;

namespace net8._0_demo;

[ApiController]
public class AppInfoController : Controller
{
    private readonly ILogger<AppInfoController> _logger;

    public AppInfoController(
        ILogger<AppInfoController> logger
    )
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/configuration")]
    public IActionResult GetConfiguration(
        [FromServices] IConfiguration config
    )
    {
        _logger.LogDebug("Will return configuration");
        var configSorted =
            config
                .AsEnumerable()
                .OrderBy(e => e.Key)
                .Select(e =>
                {
                    string? keyNew = new string(e.Key).Replace(":", "__");
                    return new { Key = keyNew, e.Value };
                })
                .ToList();

        return Ok(configSorted);
    }
}