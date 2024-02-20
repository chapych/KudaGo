using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace KudaGo.Infrastructure.Interfaces
{
    public interface IAPIAccesser
    {
        Task<IKudaGoData<T>?> GetResponseDataAsync<T>(string endpoint);
    }
}
