using KudGo.Entities.Enums;

namespace KudaGo.Infrastructure.Interfaces
{
    public interface IEndpointFactory
    {
        string Create(int pageSize, DateTime actualSince, DateTime actualUntil, Category[] categoriesField);
    }
}
