using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.Model
{
    public class CategoryItem
    {
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public byte Thumbnail { get; set; }
    }
}
