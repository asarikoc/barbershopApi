using barbershopApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

[Route("api/nearbysearch")]
[ApiController]
public class NearbySearchController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public NearbySearchController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> FindNearbyBarbers(double latitude, double longitude)
    {
        try
        {
            // TODO: Secure this api.
            var apiKey0 = _configuration["GoogleApiKey"];
            var apiKey = "AIzaSyDCxOIzeaBO_gSHGidexkOl8DBZjO398-E";
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return BadRequest("Google API key is not configured.");
            }

            var nearbyBarbers = await PerformNearbySearch(apiKey, latitude, longitude);
            return Ok(nearbyBarbers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    private async Task<List<Barber>> PerformNearbySearch(string apiKey, double latitude, double longitude)
    {
        using var httpClient = new HttpClient();

        var baseUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";
        var queryParams = new Dictionary<string, string>
        {
            { "location", $"{latitude},{longitude}" },
            { "radius", "1000" }, // Radius in meters (adjust as needed)
            { "type", "barber" }, // Change to match your desired place type
            { "key", apiKey },
        };

        var fullUrl = QueryHelpers.AddQueryString(baseUrl, queryParams);

        var response = await httpClient.GetAsync(fullUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var searchResults = JsonConvert.DeserializeObject<NearbySearchResponse>(content);
            var url = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=";
            if (searchResults != null && searchResults.results != null)
            {
                var nearbyBarbers = searchResults.results.Select(result => new Barber
                {
                    Name = result.name,
                    BarberID = result.place_id,
                    Latitude = result.geometry.location.lat,
                    Longitude = result.geometry.location.lng,
                    //ImageURL = url + result.photos[0].photo_reference,
                    ImageURL = null
                    // Add more properties as needed
                }).ToList();

                return nearbyBarbers;
            }
        }

        // Handle error responses or empty results
        return new List<Barber>();
    }
}
