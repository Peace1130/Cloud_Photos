using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_proj.ModelClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cloud_proj.Pages
{
    public class MyPhotosModel : PageModel
    {
        public Photo photos { get; set; }
        public List<Photo> PhotosList { get; set; }

       /* List<Photo> photos = new List<Photo>
        {
            new Photo(1,"galaxy","sizwe","11-01-2021",8,"C:/Users/Peace/Desktop/Pictures",2)
        };*/
        public void OnGet()
        {
        }


    }
}
