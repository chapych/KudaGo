using KudGo.Entities.Enums;
using System.Runtime.CompilerServices;
using KudaGo.Infrastructure.Interfaces;

namespace KudaGo.Infrastructure.Services;

internal class TypeConverter : ITypeConverter
{
    private readonly Dictionary<Category, string> _categoriesToString = new()
    {
        [Category.BusinessEvents] = "business-events",
        [Category.Cinema] = "cinema",
        [Category.Concert] = "concert"
    };
    
    private readonly Dictionary<string, Category> _stringToCategory = new()
    {
        ["business-events"] = Category.BusinessEvents,
        ["cinema"] = Category.Cinema,
        ["concert"] = Category.Concert
    };

    public bool TryConvertToString(Category category, out string value) => _categoriesToString.TryGetValue(category, out value);

    public bool TryConvertToCategory(string @string, out Category value) => _stringToCategory.TryGetValue(@string, out value);
}