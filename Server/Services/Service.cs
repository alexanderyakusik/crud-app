using System;
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
                    AttachCollectionItems(entity, dbContext);
                    if (entity.ID == 0)
                    {
                        entity.ID = dbContext.Set<T>().OrderByDescending((T item) => item.ID).FirstOrDefault().ID + 1;
                    }
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
                    if ((propInfo.PropertyType.IsGenericType) &&
                        (propInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
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
                    try
                    {
                        entityObject = dbContext.Set<T>().Include(collectionName).First((T entity) => entity.ID == ID);
                    }
                    catch
                    {
                        return null;
                    }
                    dynamic list = collectionProperty.GetValue(entityObject);
                    List<PropertyInfo> virtualProperties = new List<PropertyInfo>();
                    foreach (var childObject in list)
                    {
                        if (virtualProperties.Count == 0)
                        {
                            foreach (PropertyInfo propInfo in childObject.GetType().GetProperties())
                            {
                                if (propInfo.GetGetMethod().IsVirtual)
                                {
                                    virtualProperties.Add(propInfo);
                                }
                            }
                            if (virtualProperties.Count == 0)
                            {
                                break;
                            }
                        }
                        foreach (PropertyInfo virtualProp in virtualProperties)
                        {
                            virtualProp.SetValue(childObject, null);
                        }
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
            try
            {
                using (var dbContext = new UniversityStructureModel())
                {
                    newEntity.ID = updatingID;
                    Delete(updatingID);
                    Create(newEntity);
                    dbContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void AttachCollectionItems(T entity, UniversityStructureModel dbContext)
        {
            foreach (PropertyInfo propInfo in entity.GetType().GetProperties())
            {
                if (propInfo.PropertyType.IsGenericType &&
                    propInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type propType = propInfo.PropertyType.GetGenericArguments()[0];
                    dynamic list = propInfo.GetValue(entity);
                    foreach (dynamic item in list)
                    {
                        dbContext.Set(propType).Attach(item);
                    }
                }
            }
        }
    }
}
