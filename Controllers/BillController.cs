using Newtonsoft.Json;
using REST_API_MECATEC.Models;
using Microsoft.AspNetCore.Mvc;

namespace REST_API_MECATEC.Controllers;

[ApiController]
[Route("bill")]
public class BillController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BillController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    [Route("get_bill_by_id")]
    public dynamic GetBillByID(string id)
    {
        var rootPath = _webHostEnvironment.ContentRootPath;
        var fullPath = Path.Combine(rootPath, "BillsDatabase.json");
        var jsonData = System.IO.File.ReadAllText(fullPath);
        var JSONObject = jsonData;
        var allBills = JsonConvert.DeserializeObject<List<Bills>>(JSONObject);
        string filterID = id;
        var specificBillData = allBills.FirstOrDefault(s => s.billID == filterID);
        return specificBillData;
    }
}