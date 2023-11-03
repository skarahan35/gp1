using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickSell.Tools
{
    public class DevExtremeUpdate
    {
        public static async Task<T> Update<T>(T entity, IDictionary<string, object> input) where T : class
        {
            foreach (var item in input)
            {
                var cultureInfo = new CultureInfo("en-EN");
                var key = char.ToUpper(item.Key[0], cultureInfo) + item.Key.Substring(1);
                var property = entity.GetType().GetProperty(key, BindingFlags.Public | BindingFlags.Instance);

                if (property != null)
                {
                    Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                    object? safeValue = (item.Value == null) ? null :
                        targetType == typeof(System.Guid) ? Guid.TryParse(item.Value.ToString(), out Guid gr) ? gr : null :
                        targetType.IsEnum ? Enum.ToObject(targetType, item.Value) : Convert.ChangeType(item.Value, targetType);


                    property.SetValue(entity, safeValue);
                }
            }

            return entity;
        }
    }
}
