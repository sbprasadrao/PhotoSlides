using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.Model
{
    public class PhotoItem
    {
        public string FileName { get; set; }
        public string Category { get; set; }
        public string Label { get; set; }
        public Guid Id
        {
            get; set;
        }
        public byte Thumbnail { get; set; }
        public byte FullPhoto { get; set; }
    }
}
