using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System;

namespace OneTrackerDBService.DataService
{
    public class ObjToEntity
    {
        #region PublicMethods

        public bool TryAddObjToDb(object entity)
        {
            bool res = false;
            dynamic service = GetService(entity);

            if (service != null)
            {
                switch (entity)
                {
                    case Department outputDep:
                        return service.AddRecord(outputDep);

                    case DevTeam outputDev:
                        return service.AddRecord(outputDev);

                    default:
                        break;
                }
            }
            return res;
        }

        #endregion PublicMethods

        #region PrivateMethods

        private dynamic GetService(object entity)
        {
            try
            {
                Type T = entity.GetType();
                Type myGeneric = typeof(DbService<>);
                Type constructedClass = myGeneric.MakeGenericType(T);
                return Activator.CreateInstance(constructedClass); // No need to cast created object to T
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion PrivateMethods
    }
}