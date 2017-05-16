using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Server
{
    public class Service<T> : IContract<T> where T : BasicEntity, new()
    {
        public bool Create(T entity)
        {
            try
            {
                using (var dbContext = new UniversityStructureModel())
                {
                    dbContext.Set<T>().Add(entity);
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Delete(int ID)
        {
            try
            {
                using (var dbContext = new UniversityStructureModel())
                {
                    T deletingEntity = dbContext.Set<T>().First((T entity) => entity.ID == ID);
                    dbContext.Set<T>().Remove(deletingEntity);
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public T Read(int ID)
        {
            using (var dbContext = new UniversityStructureModel())
            {
                string collectionName = null;
                PropertyInfo collectionProperty = null;
                foreach (PropertyInfo propInfo in typeof(T).GetProperties())
                {
                    if (propInfo.PropertyType.IsGenericType)
                    {
                        collectionName = propInfo.Name;
                        collectionProperty = propInfo;
                        break;
                    }
                }

                T entityObject;
                if (collectionName == null)
                {
                    return dbContext.Set<T>().First((T entity) => entity.ID == ID);
                }
                else
                {
                    entityObject = dbContext.Set<T>().Include(collectionName).First((T entity) => entity.ID == ID);
                    dynamic list = collectionProperty.GetValue(entityObject);
                    PropertyInfo recursiveCollectionProperty = null;
                    foreach (var childObject in list)
                    {
                        if (recursiveCollectionProperty == null)
                        {
                            foreach (PropertyInfo propInfo in childObject.GetType().GetProperties())
                            {
                                if (propInfo.PropertyType.IsGenericType)
                                {
                                    recursiveCollectionProperty = propInfo;
                                    break;
                                }
                            }
                        }
                        recursiveCollectionProperty.SetValue(childObject, default(List<T>));
                    }
                }

                return entityObject;
            }
        }

        public List<T> ReadAll()
        {
            using (var dbContext = new UniversityStructureModel())
            {
                return dbContext.Set<T>().ToList();
            }
        }

        public bool Update(int updatingID, T newEntity)
        {
            // TODO
            try
            {
                using (var dbContext = new UniversityStructureModel())
                {
                    Delete(updatingID);
                    Create(newEntity);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
