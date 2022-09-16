using Microsoft.AspNetCore.Mvc;

namespace REST_API_MECATEC.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IWebHostEnvironment _webHostEnvironment;

    public UserController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet(Name = "GetUser")]
    public String GetUser()
    {
        var rootPath = _webHostEnvironment.ContentRootPath;
        var fullPath = Path.Combine(rootPath, "Database.json");
        var jsonData = System.IO.File.ReadAllText(fullPath);
        return jsonData;
    }

}