using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SharedLibrary.User
{
    public class UserInfo
    {
        #region Singelton

        private static readonly Lazy<UserInfo> lazy =
        new Lazy<UserInfo>(() => new UserInfo());

        public static UserInfo GetInstance
        { get { return lazy.Value; } }

        private UserInfo()
        {
            if (AppUser is null) AppUser = new Employee();
        }

        #endregion Singelton

        #region Fields

        private static Employee _AppUser;
        public Employee AppUser { get => _AppUser; set => _AppUser = value; }

        #endregion Fields

        #region PublicMethods

        public bool UserExistInDB(int userId)
        {
            var dbService = new DbService<Employee>();
            return dbService.IsPrimaryKeyInDb(userId).Result;
        }

        public async Task<bool> UserExistInDBAsync(int userId)
        {
            var dbService = new DbService<Employee>();
            return await dbService.IsPrimaryKeyInDb(userId);
        }

        #endregion PublicMethods
    }
}