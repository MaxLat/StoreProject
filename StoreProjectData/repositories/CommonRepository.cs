using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class CommonRepository : RepositoryBase<StoreProjectEntities>
    {

        
        public CommonRepository()
            : base(new StoreProjectEntities())
        {

        }
        
        // CRUD Resource
        public Resource GetResource(int resource_resourceId)
        {
            return GetFirst<Resource>(re => re.ResourceId  == resource_resourceId);
        }

        public IEnumerable<Resource> GetAllResource(int resource_resourceId)
        {
            return GetAll<Resource>(re => re.ResourceId == resource_resourceId);
        }

        public void AddResource(Resource resource)
        {
            Add(resource);
            SaveChanges();
        }

        public void RemoveResource(Resource resource)
        {
            var dbResource = GetFirst<Resource>(re => re.ResourceId == resource.ResourceId);
            Remove(dbResource);
            SaveChanges();
        }

       

        public void UpdateResource(Resource resource)
        {
            var dbResource = GetFirst<Resource>(re => re.ResourceId == resource.ResourceId);
            dbResource.Description = resource.Description ?? dbResource.Description;
            SaveChanges();
        }


        //CRUD Language 

        public Resource GetLanguage(int language_languageId)
        {
            return GetFirst<Resource>(la => la.LanguageId == language_languageId);
        }

        public IEnumerable<Resource> GetAllLanguage(int language_languageId)
        {
            return GetAll<Resource>(la => la.LanguageId == language_languageId);
        }

        public void AddLanguage(Language language)
        {
            Add(language);
            SaveChanges();
        }

        public void RemoveLanguage(Language language)
        {
            var dbLanguage = GetFirst<Language>(la => la.languageId == language.languageId);
            Remove(dbLanguage);
            SaveChanges();
        }



        public void UpdateResource(Language language )
        {
            var dbLanguage = GetFirst<Language>(la => la.languageId == language.languageId);
            dbLanguage.label = language.label ?? dbLanguage.label;
            SaveChanges();
        }





    }
}
