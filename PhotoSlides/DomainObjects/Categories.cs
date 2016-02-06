using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.DomainObjects
{
    public enum Categories
    {
        [Description("General"), Guid("39726D4F-FC05-41D6-A0E1-B69E6C054D4A")]
        General,
        [Description("Places"), Guid("1A426502-D4B9-4E56-BC2B-F303DD7D390F")]
        Places,
        [Description("Relatives"), Guid("E36C6765-2D6F-4F04-AEA7-C4D9D697FA92")]
        Relatives,
        [Description("Animals"), Guid("B1C61342-993E-4773-A9AD-7D688CB8C126")]
        Animals
    }

    public class DescriptionAttribute : Attribute
    {
        public string Name { get; private set; }
        public DescriptionAttribute(string name)
        {
            Name = name;
        }
    }

    public class GuidAttribute : Attribute
    {
        public string Name { get; private set; }
        public GuidAttribute(string name)
        {
            Name = name;
        }
    }
}
