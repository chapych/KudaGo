using KudGo.Entities.Entitites;

namespace KudaGo.UseCases;

public interface IKudaGoService
{
    Task<List<Event>> GetEventsAsync(KudaGoRequest request);
}