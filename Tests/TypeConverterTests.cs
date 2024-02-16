using System.ComponentModel;
using KudaGo.Infrastructure.Interfaces;
using KudGo.Entities.Enums;
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

            var categoryString1 = _typeConverter.ConvertToString(category1);
            var categoryString2= _typeConverter.ConvertToString(category2);
            var categoryString3 = _typeConverter.ConvertToString(category3);

            Assert.Multiple(() =>
            {
                Assert.That(categoryString1, Is.EqualTo("business-events"));
                Assert.That(categoryString2, Is.EqualTo("cinema"));
                Assert.That(categoryString3, Is.EqualTo("concert"));
            });
            
        }
    }
}