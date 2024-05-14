using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iit10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomizerController : ControllerBase
    {
        private Random _random;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<string> Countries = new List<string>
        {
            "Australia", "USA", "Canada", "UK", "Germany", "France", "Japan", "China", "India", "Brazil"
        };

        private static readonly List<string> Cities = new List<string>
        {
            "New York", "London", "Paris", "Tokyo", "Sydney", "Beijing", "Berlin", "Rome", "Moscow", "Toronto"
        };

        private static readonly List<int> Numbers = new List<int>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        private static readonly List<string> Flowers = new List<string>
        {
            "Rose", "Tulip", "Sunflower", "Lily", "Daisy", "Orchid", "Carnation", "Daffodil", "Peony", "Hydrangea"
        };

        private static readonly List<string> Animals = new List<string>
        {
            "Dog", "Cat", "Elephant", "Lion", "Tiger", "Giraffe", "Horse", "Monkey", "Penguin", "Dolphin"
        };

        private static readonly List<string> Colors = new List<string>
        {
            "Red", "Blue", "Green", "Yellow", "Orange", "Purple", "Pink", "Brown", "Black", "White"
        };

        public RandomizerController()
        { 
            _random = new Random();
        }

        [HttpGet("home")]
        public IEnumerable<WeatherForecast> Home()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("city")]
        public ActionResult<string> City()
        {
            return GetRandom(Cities);
        }

        [HttpGet("country")]
        public ActionResult<string> Country()
        {
            return GetRandom(Countries);
        }

        [HttpGet("number")]
        public ActionResult<int> Number()
        {
            return GetRandom(Numbers);
        }

        [HttpGet("flower")]
        public ActionResult<string> Flower()
        {
            return GetRandom(Flowers);
        }

        [HttpGet("animal")]
        public ActionResult<string> Animal()
        {
            return GetRandom(Animals);
        }

        [HttpGet("color")]
        public ActionResult<string> Color()
        {
            return GetRandom(Colors);
        }

        private T GetRandom<T>(List<T> list)
        {
            var index =  _random.Next(list.Count - 1);
            return list[index];
        }
    }
}
