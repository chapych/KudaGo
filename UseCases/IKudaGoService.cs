using Entities.Entitites;

namespace UseCases;

public interface IKudaGoService
{
    Task<List<Event>> GetEventsAsync(KudaGoRequest request);
}