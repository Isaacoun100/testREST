using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API_MECATEC.Models;

namespace REST_API_MECATEC.Controllers;


[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ClientController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    [HttpGet]
    [Route("get_client_by_name")]
    public dynamic GetClientByName(string clientName)
    {
        var rootPath = _webHostEnvironment.ContentRootPath;
        var fullPath = Path.Combine(rootPath, "ClientDatabase.json");
        var jsonData = System.IO.File.ReadAllText(fullPath);
        var JSONObject = jsonData;
        var allClients = JsonConvert.DeserializeObject<List<Client>>(JSONObject);
        string filterName = clientName.Replace(" ","");
        var specificClientData = allClients.FirstOrDefault(s => s.name.Replace(" ","") == filterName);
        return specificClientData;

    }
}