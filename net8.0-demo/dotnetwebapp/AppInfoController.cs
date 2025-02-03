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
                .OrderBy(e => e.Key);

        return Ok(configSorted);
        
    }
}