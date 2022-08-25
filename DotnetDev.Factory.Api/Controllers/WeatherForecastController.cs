using DotnetDev.Factory.Api.CreditCard;
using Microsoft.AspNetCore.Mvc;

namespace DotnetDev.Factory.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ICreditCardFactory _creditCardFactory;

    public WeatherForecastController(ICreditCardFactory creditCardFactory)
    {
        _creditCardFactory = creditCardFactory;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var stripeProvider = _creditCardFactory.GetProvider(1);
        var cloverProvider = _creditCardFactory.GetProvider(2);
        
        return Ok();
    }
}