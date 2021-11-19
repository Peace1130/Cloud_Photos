using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_proj.ModelClass
{
    public class Photo
    {
        

        [Key]
        public int Id { get; set; }
        public string PhotoName { get; set; }
        public string capturedBy { get; set; }
        public string captureDdate { get; set; }

        public int size { get; set; }

        public string path { get; set; }
        public int NoOfViews { get; set; }

        public Photo()
        {

        }
        public Photo(int Id, string PhotoName, string capturedBy, string captureDdate, int size, string path, int NoOfViews)
        {
            this.Id = Id;
            this.PhotoName = PhotoName;
            this.capturedBy = capturedBy;
            this.captureDdate = captureDdate;
            this.size = size;
            this.path = path;
            this.NoOfViews = NoOfViews;
        }



        [NotMappedAttribute]
        [Required(ErrorMessage = "A Picture is required.")]
        public List<IFormFile> filePhoto { get; set; }

      

    }
}
