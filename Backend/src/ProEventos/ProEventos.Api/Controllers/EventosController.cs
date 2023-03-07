using Microsoft.AspNetCore.Mvc;
using ProEventos.Infra.Context;

namespace ProEventos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    //private readonly ILogger<EventosController> _logger;
    private readonly ProEventosContext _context;
    public EventosController(ProEventosContext context/*ILogger<EventosController> logger*/  )
    {
        _context = context;
        //_logger = logger;
    }


    [HttpGet]
    public IEnumerable<IActionResult> Get()
    {
        return (IEnumerable<IActionResult>)Ok("ok");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
}