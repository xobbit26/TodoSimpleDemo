using Microsoft.AspNetCore.Mvc;
using TodoSimpleDemo.Domain.Entities;

namespace TodoSimpleDemo.Web.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;

    public TodoController(ILogger<TodoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Todo> Get()
    {
        return new List<Todo>();
    }
}