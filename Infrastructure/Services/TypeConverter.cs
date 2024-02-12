using Entities.Enums;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class TypeConverter : ITypeConverter
{
    private readonly Dictionary<Category, string> _categoriesToString = new()
    {
        [Category.BusinessEvents] = "business-events",
        [Category.Cinema] = "cinema",
        [Category.Concert] = "concert"
    };

    public string ConvertToString(Category category) => _categoriesToString[category];
}