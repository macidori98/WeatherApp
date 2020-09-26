﻿using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
  public class AccuWeatherHelper
  {
    public const string BASE_URL = "http://dataservice.accuweather.com/";
    public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
    public const string API_KEY = "RLtOdPUgeoGtSLAZ3633S2CDPSDy9JSy";
    public const string CURRENT_CONDITION_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

    public static async Task<List<City>> GetCities(string query)
    {
      List<City> cities = new List<City>();

      string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

      using (HttpClient client = new HttpClient())
      {
        var resp = await client.GetAsync(url);
        string json = await resp.Content.ReadAsStringAsync();

        cities = JsonConvert.DeserializeObject<List<City>>(json);
      };

      return cities;
    }

    public static async Task<CurrentCondition> GetCurrentConditions(string cityKey)
    {
      CurrentCondition currentCondition = new CurrentCondition();

      string url = BASE_URL + string.Format(CURRENT_CONDITION_ENDPOINT, cityKey, API_KEY);

      using (HttpClient client = new HttpClient())
      {
        var resp = await client.GetAsync(url);
        string json = await resp.Content.ReadAsStringAsync();

        currentCondition = JsonConvert.DeserializeObject<List<CurrentCondition>>(json).FirstOrDefault();
      };

      return currentCondition;
    }
  }
}