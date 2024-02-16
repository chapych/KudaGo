using System.Runtime.CompilerServices;
using KudaGo.Infrastructure.Models;

[assembly: InternalsVisibleTo("Tests")]
namespace KudaGo.Infrastructure.Interfaces
{
    internal interface IAPIAccesser
    {
        Task<ResponseData?> GetResponseDataAsync(string endpoint);
    }
}
