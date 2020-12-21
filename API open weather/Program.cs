using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace API_open_weather
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
        
            Console.WriteLine("Enter city you would like weather forecast to receive");
            var cityName = Console.ReadLine().ToLower();

            var apiKey = "ade19c9281423758e4494e4bb8119c22";



            var responseWeather = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&units=metric&lang=lt&appid=" + apiKey);


            var responseWeatherBody = await responseWeather.Content.ReadAsStringAsync();


            var myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseWeatherBody);

            
           
            Console.WriteLine($"Current temperature in {cityName} is {myDeserializedClass.main.temp}C and it feels like {myDeserializedClass.main.feels_like}C  Today's day temperature from {myDeserializedClass.main.temp_min}C to {myDeserializedClass.main.temp_max}C");
            
        }
            
    }
}
