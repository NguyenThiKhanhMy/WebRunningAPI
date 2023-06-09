using System.Collections.Generic;

namespace WebRunning.API.ViewModel.Portal
{
    public class Images
    {
        public string alt { get; set; }
        public string name { get; set; }
        public string src { get; set; }
        public string tag { get; set; }
    }
    public class ImageGallery
    {
        public int statusCode { get; set; }
        public List<Images> result { get; set; }

    }
}
