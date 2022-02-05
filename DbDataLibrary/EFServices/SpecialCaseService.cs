using DbDataLibrary.Logger;
using DbDataLibrary.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DbDataLibrary.Logger.LogHelper;

namespace DbDataLibrary.EFServices
{
    public class SpecialCaseService
    {
        #region Fields

        private OneTrackerDBContext oneTrackerDBContext;

        #endregion Fields

        #region Employee

        public async Task<List<Employee>> GetAllEmployee()
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                return await oneTrackerDBContext.Employee
                    .Include(d => d.DepartamentNavigation)
                    .Include(t => t.TeamNavigation)
                    .ToListAsync();
            }
        }

        public Employee GetUserByCompanyId(string comId)
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                var findItem = oneTrackerDBContext.Employee.First(e => e.IdEmployee == comId);
                return findItem;
            }
        }

        public async Task<Employee> GetUserByIdAsync(int Id)
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                var findItem = await oneTrackerDBContext.Employee.FindAsync(Id);
                return findItem;
            }
        }

        public async Task<bool> AddProject(Project project)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    await oneTrackerDBContext.Project.AddAsync(project);
                    await oneTrackerDBContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Employee

        #region DevTeam

        public async Task<DevTeam> GetDevTeamById(int Id)
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                var result = await oneTrackerDBContext.DevTeam.FindAsync(Id);
                await oneTrackerDBContext.Entry(result)
                     .Collection(e => e.Employee).LoadAsync();
                return result;
            }
        }

        public async Task<List<DevTeam>> GetDevTeam()
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                return await oneTrackerDBContext.DevTeam
                    .Include(t => t.DepartamentNavigation)
                    .ToListAsync();
            }
        }

        #endregion DevTeam

        #region Projects

        public async Task<List<Project>> GetAllOpenProjects()
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                return await oneTrackerDBContext.Project
                    .Include(d => d.DeveloperNavigation)
                    .Include(t => t.DevTeamNavigation)
                    .ToListAsync();
            }
        }

        #endregion Projects

        #region CloseProjects

        public async Task<List<ProjectFinalized>> GetAllCloseProjects()
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    return await oneTrackerDBContext.ProjectFinalized.ToListAsync();
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.Message);
                return new List<ProjectFinalized>();
            }
        }

        #endregion CloseProjects
    }
}