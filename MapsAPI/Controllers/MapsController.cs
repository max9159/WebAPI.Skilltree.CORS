using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MapsAPI.Models;
using Newtonsoft.Json;

namespace MapsAPI.Controllers
{
    public class MapsController : ApiController
    {
        private static HttpClient client = new HttpClient();
        private static string mapUri = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        private static string gMapKey = "&key=AIzaSyBd0HRR1RLqpk934ErdeywXszgm6hGw8eU";
        public async Task<IHttpActionResult> Get()
        {
            string addressUri = mapUri + "台北市大安區金華街199巷5號" + gMapKey;
            var response = await client.GetAsync(addressUri);
            response.EnsureSuccessStatusCode();
            //var result = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadAsStringAsync();
            // add this code
            var maps = JsonConvert.DeserializeObject<Maps>(result);
            //var resultObj = await response.Content.ReadAsAsync<Maps>();

            return Ok(result);
        }
    }
}
