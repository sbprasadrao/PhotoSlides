using PhotoSlides.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.View
{
    public enum Views
    {
        [Description("Albums")]
        Albums,
        [Description("Settings")]
        Settings,
        [Description("Favorites")]
        Favorites
    }
}
