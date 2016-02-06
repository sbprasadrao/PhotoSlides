using PhotoSlides.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.Utility
{
    public static class EnumUtility
    {
        public static string GuidString<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            GuidAttribute[] attributes = (GuidAttribute[])fi.GetCustomAttributes(
                typeof(GuidAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Name;
            else return source.ToString();
        }

        public static string Description<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Name;
            else return source.ToString();
        }
    }
}
