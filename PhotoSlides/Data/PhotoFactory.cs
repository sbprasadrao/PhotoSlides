using PhotoSlides.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PhotoSlides.DomainObjects;
using PhotoSlides.Utility;

namespace PhotoSlides.Data
{
    public class PhotoFactory
    {
        
        public static List<CategoryItem> GetCategories()
        {
            List<CategoryItem> items = new List<CategoryItem>()
            {
                new CategoryItem() {CategoryId = new Guid(Categories.General.GuidString()), CategoryName = Categories.General.Description()  }
            };

            return items;            
        }
    }
    
    

    
}
