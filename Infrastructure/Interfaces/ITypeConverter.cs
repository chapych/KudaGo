using KudGo.Entities.Enums;

namespace KudaGo.Infrastructure.Interfaces;

internal interface ITypeConverter
{
    string ConvertToString(Category category);
}