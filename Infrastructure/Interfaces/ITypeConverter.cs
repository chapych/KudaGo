using KudGo.Entities.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace KudaGo.Infrastructure.Interfaces;

internal interface ITypeConverter
{
    string ConvertToString(Category category);
}