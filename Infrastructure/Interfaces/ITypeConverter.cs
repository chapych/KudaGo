using KudGo.Entities.Enums;

namespace KudaGo.Infrastructure.Interfaces;

public interface ITypeConverter
{
    bool TryConvertToString(Category category, out string value);
    bool TryConvertToCategory(string @string, out Category value);
}