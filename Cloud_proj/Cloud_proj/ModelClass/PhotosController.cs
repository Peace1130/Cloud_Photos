using Cloud_proj.Pages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_proj.ModelClass
{
    public class PhotosController : Controller
    {
        AuthDbContext authDb;
        public PhotosController(AuthDbContext authDb)
        {
            this.authDb = authDb;
        }

        public IActionResult Index()
        {
            MyPhotosModel photoMod = new MyPhotosModel();
            photoMod.PhotosList = authDb.Photo.ToList();
            photoMod.photos = new Photo();
            return View(photoMod);
        }



        [HttpPost]
        public IActionResult AddPhotos(MyPhotosModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var Files = model.photos.filePhoto;

            if (Files.Count > 0)
            {
                foreach (var item in Files)
                {
                    Photo photo = new Photo();
                    var guid = Guid.NewGuid().ToString();
                    var filePath = "wwwroot/Photo/" + guid + item.FileName;
                    var fileName = guid + item.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyTo(stream);
                        photo.PhotoName = fileName;
                        photo.path = filePath;
                        photo.capturedBy = "Sizwe Madlala";
                        photo.captureDdate = "30-11-2021";
                        photo.NoOfViews = 1;
                        authDb.Photo.Add(photo);
                        authDb.SaveChanges();
                    }
                }
                return RedirectToAction("MyPhotos");
            }


            return RedirectToAction("MyPhotos");
        }

        public IActionResult DeletePhoto(int id)
        {

            var photo = authDb.Photo.Find(id);
            if (photo != null)
            {

                authDb.Photo.Remove(photo);
                authDb.SaveChanges();
            }
            return RedirectToAction("MyPhotos");
        }
    }
}
