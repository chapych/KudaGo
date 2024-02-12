using Entities.Enums;

namespace Infrastructure.Interfaces;

public interface ITypeConverter
{
    string ConvertToString(Category category);
}