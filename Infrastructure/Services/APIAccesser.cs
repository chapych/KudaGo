using System.Net.Http.Json;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class APIAccesser : IAPIAccesser
{
    private readonly HttpClient _httpClient;

    public APIAccesser(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseData?> GetResponseDataAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        var responseData = await response.Content.ReadFromJsonAsync<ResponseData>();
        return responseData;
    }
}