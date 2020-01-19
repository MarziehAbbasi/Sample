using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [Produces("application/json", "application/xml")]
    //[Route("api/authors/{authorId}/books")]
    [Route("api/[controller]")]
    [ApiController]

    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }


        [HttpPost("[action]")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // Post: api/CreateweatherForecast/WeatherForecast
        public ActionResult<WeatherForecast> CreateweatherForecast([FromBody]WeatherForecast weatherForecast)
        {
            weatherForecast = new WeatherForecast
            {
                DateFormatted = DateTime.Now.ToString("d"),
                TemperatureC = 20,
                Summary = Summaries[0]
            };
            if (weatherForecast != null)
            {
                return Ok(weatherForecast);
            }
            return NotFound();
        }
        /*
        public WeatherForecast AddWeatherForecast(WeatherForecast weatherForecast)
        {
            var id = 1;
            var lastItem = new WeatherForecast();
            return lastItem;
        }*/

        /// <summary>
        /// An WeatherForecast with DateFormatted, TemperatureC and Summary fields
        /// </summary>
        public class WeatherForecast
        {
            /// <summary>
            /// The last DateFormatted of the WeatherForecast
            /// </summary>
            public string DateFormatted { get; set; }
            /// <summary>
            /// The last TemperatureC of the WeatherForecast
            /// </summary>
            public int TemperatureC { get; set; }
            /// <summary>
            /// The last Summary of the WeatherForecast
            /// </summary>
            public string Summary { get; set; }
            /// <summary>
            /// The last TemperatureF of the WeatherForecast
            /// </summary>
            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
