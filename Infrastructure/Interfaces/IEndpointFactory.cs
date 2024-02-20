using KudGo.Entities.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace KudaGo.Infrastructure.Interfaces
{
    public interface IEndpointFactory
    {
        string Create(int pageSize, DateTime actualSince, DateTime actualUntil, Category[] categoriesField);
    }
}
