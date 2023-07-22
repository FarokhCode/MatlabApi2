using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MatlabApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatlabDemoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<MatlabDemoController> _logger;

        public MatlabDemoController(ILogger<MatlabDemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public object Get()
        {
            int a=5,b=30,c=5,d=30;
            // Create the MATLAB instance 
            MLApp.MLApp matlab = new MLApp.MLApp();

            // Change to the directory where the function is located 
            matlab.Execute(@"cd D:\farokh\Matlab");

            // Define the output 
            object result = null;

            // Call the MATLAB function myfunc
            matlab.Feval("untitled2", 2, out result, a, b,c,d );

            // Display result 
            object[] res = result as object[];

            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
            matlab.Quit();
            //Console.ReadLine();
            return res;

            //test
           /* return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}
