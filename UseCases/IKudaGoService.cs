using KudGo.Entities.Entities;

namespace KudaGo.UseCases;

public interface IKudaGoService
{
    Task<List<Event>> GetEventsAsync(KudaGoRequest request);
}