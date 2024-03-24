using System.ComponentModel.DataAnnotations;
using KudaGo.Entities.Entities;
using KudaGo.Infrastructure.Interfaces;
using KudaGo.Infrastructure.Models;
using KudaGo.UseCases;
using KudGo.Entities.Entities;
using KudaGoEvent = KudaGo.Entities.Entities.KudaGoEvent;

namespace KudaGo.Infrastructure.Services;

public class KudaGoService : IKudaGoService
{
    private readonly IAPIAccesser _apiAccesser;
    private readonly IEndpointFactory _endpointFactory;
    private readonly ITypeConverter _typeConverter;

    private const int DAYS_BEFORE = 1;
    private const int DAYS_AFTER = 7;

    public KudaGoService(IAPIAccesser apiAccesser, IEndpointFactory endpointFactory, ITypeConverter typeConverter)
    {
        _apiAccesser = apiAccesser;
        _endpointFactory = endpointFactory;
        _typeConverter = typeConverter;
    }

    public async Task<List<KudaGoEvent>> GetEventsAsync(KudaGoRequest request)
    {
        var targetCount = request.Count;
        var events = new List<KudaGoEvent>(targetCount);

        var endpoint = GetEndpoint(request);
        var responseData = await _apiAccesser.GetResponseDataAsync<Models.KudaGoEvent>(endpoint);

        var currentEventsCount = 0;
        while(currentEventsCount != targetCount && responseData != null)
        {
            events.AddRange(GetEvents(responseData)
                .Take(targetCount - currentEventsCount));
            
            currentEventsCount = events.Count;

            endpoint = responseData.Next;

            if (string.IsNullOrEmpty(endpoint)) 
                break;

            responseData = await _apiAccesser.GetResponseDataAsync<Models.KudaGoEvent>(endpoint);
        }
        return events;
    }

    private string GetEndpoint(KudaGoRequest request)
    {
        var dataSince = request.Date.AddDays(-DAYS_BEFORE);
        var dataUntil = request.Date.AddDays(DAYS_AFTER);

        var endpoint = _endpointFactory.Create(
            request.Count, 
            dataSince, 
            dataUntil, 
            request.Categories);
        return endpoint;
    }

    private IEnumerable<KudaGoEvent> GetEvents(IKudaGoData<Models.KudaGoEvent> responseData) =>
        responseData.Events.Select(x =>
            new KudaGoEvent(
                x.Name,
                x.Description,
                x.Dates?.Select(d => (d.Start, d.End)),
                x.Categories?.Select(c =>
                {
                    var found = _typeConverter.TryConvertToCategory(c, out var value);
                    return (Key: c, Value: value, Found: found);
                })
                .Where(tuple => tuple.Found)
                .Select(tuple => tuple.Value)));
}