using Entities.Entitites;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using UseCases;

namespace Infrastructure.Services;

public class KudaGoService : IKudaGoService
{
    private readonly IAPIAccesser _apiAccesser;
    private readonly IEndpointFactory _endpointFactory;

    private const int DAYS_BEFORE = 1;
    private const int DAYS_AFTER = 7;

    internal KudaGoService(IAPIAccesser apiAccesser, IEndpointFactory endpointFactory)
    {
        _apiAccesser = apiAccesser;
        _endpointFactory = endpointFactory;
    }

    public async Task<List<Event>> GetEventsAsync(KudaGoRequest request)
    {
        var dataSince = request.Date.AddDays(-DAYS_BEFORE);
        var dataUntil = request.Date.AddDays(DAYS_AFTER);

        var endpoint = _endpointFactory.Create(
            request.Count, 
            dataSince, 
            dataUntil, 
            request.Categories);

        var responseData = await _apiAccesser.GetResponseDataAsync(endpoint);

        var events = new List<Event>(request.Count);
        var count = 0;
        while(count != request.Count && responseData != null)
        {
            events.AddRange(GetEvents(responseData).Take(request.Count - count));
            count = events.Count;

            endpoint = responseData.Next;
            if (endpoint == null) break;

            responseData = await _apiAccesser.GetResponseDataAsync(endpoint);
        }
        return events;
    }

    private static IEnumerable<Event> GetEvents(ResponseData responseData) =>
        responseData.Events.Select(x =>
            new Event(
                x.Name,
                x.Description,
                x.Dates?.Select(d => d.ToDateTime()
                ))
        );


}