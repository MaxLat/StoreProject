using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class ProductPhotoRepository : RepositoryBase<StoreProjectEntities>
    {
        public ProductPhotoRepository()
          : base(new StoreProjectEntities())
        {
        }

        public IEnumerable<Products_Photo> GetAllProductPhoto()
        {
            return GetAll<Products_Photo>();
        }

        public IEnumerable<Products_Photo> GetProductPhoto (int productId)
        {
            return  GetAll<Products_Photo>(pr => pr.ProductsId == productId);
        }

        public void AddProductPhoto(Products_Photo photo)
        {
            Add(photo);
            SaveChanges();
        }

        public void RemoveProductPhoto(Products_Photo photo)
        {
            var dbProductPhoto = GetFirst<Products_Photo>(pr => pr.ProductsId == photo.ProductsId && pr.ProductsPhotoId == photo.ProductsPhotoId);
            Remove(photo);
            SaveChanges();
        }

        public void UpdateProductPhoto(Products_Photo photo)
        {
            var dbProductPhoto = GetFirst<Products_Photo>(pr => pr.ProductsId == photo.ProductsId && pr.ProductsPhotoId == photo.ProductsPhotoId);
            dbProductPhoto.Url_Photo = photo.Url_Photo ?? dbProductPhoto.Url_Photo;
            SaveChanges();
        }


    }
}
