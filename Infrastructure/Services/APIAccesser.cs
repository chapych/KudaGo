using System.Net.Http.Json;
using KudaGo.Infrastructure.Interfaces;
using KudaGo.Infrastructure.Models;

namespace KudaGo.Infrastructure.Services;

internal class APIAccesser : IAPIAccesser
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