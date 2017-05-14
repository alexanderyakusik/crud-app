using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class Service<T> : IContract<T> where T : BasicEntity, new()
    {
        public UniversityStructureModel DBContext { get; private set; }

        public Service()
        {
            DBContext = new UniversityStructureModel();
        }

        public bool Create(T entity)
        {
            bool result = true;
            try
            {
                DBContext.Set<T>().Add(entity);
                DBContext.SaveChanges();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public bool Delete(int ID)
        {
            bool result = false;
            try
            {
                T deletingEntity = DBContext.Set<T>().First((T entity) => entity.ID == 1);
                DBContext.Set<T>().Remove(deletingEntity);
                DBContext.SaveChanges();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public T Read(int ID)
        {
            return DBContext.Set<T>().First((T entity) => entity.ID == ID);
        }

        public List<T> ReadAll()
        {
            // TODO
            return DBContext.Set<T>().Cast<T>().ToList();
        }

        public bool Update(int updatingID, T newEntity)
        {
            // TODO
            bool result = true;
            try
            {
                Delete(updatingID);
                Create(newEntity);
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
