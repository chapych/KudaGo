using KudaGo.Infrastructure.Interfaces;
using KudGo.Entities.Enums;

namespace KudaGo.Infrastructure.Services;

internal class TypeConverter : ITypeConverter
{
    private readonly Dictionary<Category, string> _categoriesToString = new()
    {
        [Category.BusinessEvents] = "business-events",
        [Category.Cinema] = "cinema",
        [Category.Concert] = "concert"
    };

    public string ConvertToString(Category category) => _categoriesToString[category];
}