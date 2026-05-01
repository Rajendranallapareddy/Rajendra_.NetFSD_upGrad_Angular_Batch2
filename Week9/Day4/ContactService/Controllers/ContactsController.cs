
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    static List<object> data = new();

    [HttpGet]
    public IActionResult Get() => Ok(data);

    [HttpPost]
    public IActionResult Post(object c)
    {
        data.Add(c);
        return Ok(c);
    }
}
