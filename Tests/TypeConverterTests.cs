using KudaGo.Infrastructure.Interfaces;
using KudGo.Entities.Enums;
using System.ComponentModel;
using TypeConverter = KudaGo.Infrastructure.Services.TypeConverter;

namespace Tests
{
    internal class TypeConverterTests
    {
#pragma warning disable CA1859
        private readonly ITypeConverter _typeConverter = new TypeConverter();
#pragma warning restore CA1859

        [Test]
        public void ConvertToString_Successful()
        {
            var category1 = Category.BusinessEvents;
            var category2 = Category.Cinema;
            var category3 = Category.Concert;
            
            _typeConverter.TryConvertToString(category1, out var categoryString1);
            _typeConverter.TryConvertToString(category2, out var categoryString2);
            _typeConverter.TryConvertToString(category3, out var categoryString3);

            Assert.Multiple(() =>
            {
                Assert.That(categoryString1, Is.EqualTo("business-events"));
                Assert.That(categoryString2, Is.EqualTo("cinema"));
                Assert.That(categoryString3, Is.EqualTo("concert"));
            });
            
        }
    }
}