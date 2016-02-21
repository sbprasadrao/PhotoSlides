using PhotoSlides.Framework;
using PhotoSlides.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.ViewModel
{
    public class GroupViewModel : BaseViewModel
    {
        public string Name { get; set; } = "Initialized";

        public List<PhotoItem> Photos { get; set; }

        public List<string> Categories { get; set; }

        public string Title { get; set; }


        public GroupViewModel()
        {
            Categories = new List<string> { "General", "Places", "Relatives", "Animals" };
        }

        private bool _isLoaded;

        protected override async void OnViewLoadAsync()
        {
            base.OnViewLoadAsync();

            if (!_isLoaded)
            {
                load();
                _isLoaded = true;
            }
        }

        private void load()
        {
            Categories = new List<string> { "General", "Places", "Relatives", "Animals" };
        }
    }
}
