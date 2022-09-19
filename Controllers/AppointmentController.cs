using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REST_API_MECATEC.Models;



namespace REST_API_MECATEC.Controllers;


[ApiController]
[Route("appointment")]
public class AppointmentController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AppointmentController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost]
    [Route("save_appointment")]
    public dynamic PostAppointment(Appointment appointment)
    {

        var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(appointment);
        Console.WriteLine(jsonStr);
        System.IO.File.WriteAllText("AppointmentDatabase.json",jsonStr);
        return new
        {
            success = true,
            message = "appointment saved",
            result = appointment
        };

    }
    
    
}