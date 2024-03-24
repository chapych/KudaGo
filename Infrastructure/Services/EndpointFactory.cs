using System.Web;
using KudaGo.Infrastructure.Configurations;
using KudaGo.Infrastructure.Interfaces;
using KudGo.Entities.Enums;
using Microsoft.Extensions.Options;

namespace KudaGo.Infrastructure.Services;

internal class EndpointFactory : IEndpointFactory
{
    private readonly ITypeConverter _typeConverter;

    private readonly string _version;
    private readonly string _host;

    private const string CONTROLLER_NAME = "events";
    //private const string FIELDS = "fields=id,place,location,dates,description,coords,address,title,subway,price";
    //private const string EXPAND = "expand=place";
    private const string CATEGORIES = "categories";
    private const string LOCATION = "location";
    private const string PAGE_SIZE = "page_size";
    private const string ACTUAL_SINCE = "actual_since";
    private const string ACTUAL_UNTIL = "actual_until";
    private const string TEXT_FORMAT = "text_format";
    private const string FIELDS = "fields";


    public EndpointFactory(IOptions<KudaGoSettings> settings, ITypeConverter typeConverter)
    {
        _typeConverter = typeConverter;
        _host = settings.Value.Host;
        _version = settings.Value.Version;
    }

    public string Create(int pageCount, DateTime dataSince, DateTime dataUntil, Category[] categoriesField)
    {
        var builder = new UriBuilder
        {
            Scheme = "https",
            Host = _host,
            Path = _version + "/" + CONTROLLER_NAME + "/"
        };


        var parameters = HttpUtility.ParseQueryString(string.Empty);

        parameters[LOCATION] = "msk";
        parameters[PAGE_SIZE] = pageCount.ToString();
        parameters[ACTUAL_SINCE] = ((DateTimeOffset)dataSince).ToUnixTimeSeconds().ToString();
        parameters[ACTUAL_UNTIL] = ((DateTimeOffset)dataUntil).ToUnixTimeSeconds().ToString();
        parameters[CATEGORIES] = GetCategories(categoriesField);
        parameters[TEXT_FORMAT] = "text";
        parameters[FIELDS] = "id,title,slug,description,categories";

        builder.Query = parameters.ToString();

        var uri = builder.Uri;

        return uri.ToString();
    }

    private string GetCategories(Category[] categories)
    {
        if (categories == null)
            return "";

        var categoriesField = "";
        var length = categories.Length;
        for (var index = 0; index < length; index++)
        {
            var category = categories[index];

            if (category == Category.None || !_typeConverter.TryConvertToString(category, out var value))
                continue;

            categoriesField += value;
            if (NotLastIndex(index))
                categoriesField += ",";
        }

        return categoriesField;

        bool NotLastIndex(int index)
        {
            return index != length - 1;
        }
    }
}