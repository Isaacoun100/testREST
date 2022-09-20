using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API_MECATEC.Models;

namespace REST_API_MECATEC.Controllers;

[ApiController]
[Route("employee")]
public class EmployeeController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public EmployeeController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    [HttpGet]
    [Route("get_employee_by_name")]
    public dynamic GetEmployeeByName(string name)
    {
        var rootPath = _webHostEnvironment.ContentRootPath;
        var fullPath = Path.Combine(rootPath, "EmployeeDatabase.json");
        var jsonData = System.IO.File.ReadAllText(fullPath);
        var JSONObject = jsonData;
        var allEmployees = JsonConvert.DeserializeObject<List<Employee>>(JSONObject);
        string filterName = name;
        var specificEmployeeData = allEmployees.FirstOrDefault(s => s.name == filterName);
        return specificEmployeeData;

    }

    [HttpPost]
    [Route("save_employee")]
    public dynamic PostEmployee(Employee employee)
    {
        var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
        Console.WriteLine(jsonStr);
        System.IO.File.WriteAllText("EmployeeDatabaseTest.json",jsonStr);
        return new
        {
            success = true,
            message = "employee saved",
            result = employee
        };
    }
}