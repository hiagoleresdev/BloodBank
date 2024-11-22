using System.ComponentModel;
using System.Reflection;

namespace BloodBank.Core.Extentions
{
    public static class EnumExtentions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
    }
}
