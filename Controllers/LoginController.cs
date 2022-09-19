using Microsoft.AspNetCore.Mvc;
using REST_API_MECATEC.Models;

namespace REST_API_MECATEC.Controllers;
[ApiController]
[Route("login")]
public class LoginController : ControllerBase
{
    
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LoginController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    [Route("get_users")]
    public dynamic GetUsers()
    {
        var rootPath = _webHostEnvironment.ContentRootPath;
        var fullPath = Path.Combine(rootPath, "Database.json");
        var jsonData = System.IO.File.ReadAllText(fullPath);
        return jsonData;
        
    }
}