using KudaGo.Entities.Entities;
using KudGo.Entities.Entities;

namespace KudaGo.UseCases;

public interface IKudaGoService
{
    Task<List<KudaGoEvent>> GetEventsAsync(KudaGoRequest request);
}