using DbDataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibrary.Developer
{
    public class FindFreeDeveloper : IDisposable
    {
        #region Constructor

        public FindFreeDeveloper(DevTeam lookInDevTeam)
        {
            _LookInDevTeam = lookInDevTeam;
        }

        #endregion Constructor

        #region Fields

        private DevTeam _LookInDevTeam;

        //[Range(1, 100, ErrorMessage = "The field {0} must be greater than {1}.")]
        private byte _NormalWeight = 10;

        //[Range(1, 100, ErrorMessage = "The field {0} must be greater than {1}.")]
        private byte _AfterDeadlineWeight = 30;

        //[Range(1, 100, ErrorMessage = "The field {0} must be greater than {1}.")]
        private byte _CriticalProjectsWeight = 50;

        //[Range(1, 12, ErrorMessage = "The field {0} must be greater than {1}.")]
        private byte _HowManyMonthPior = 3;

        private bool disposedValue;

        #endregion Fields

        #region Properiets

        public double WeightSum
        {
            get => NormalWeight + AfterDeadlineWeight + CriticalProjectsWeight;
        }

        public byte NormalWeight { get => _NormalWeight; set => _NormalWeight = value; }
        public byte AfterDeadlineWeight { get => _AfterDeadlineWeight; set => _AfterDeadlineWeight = value; }
        public byte CriticalProjectsWeight { get => _CriticalProjectsWeight; set => _CriticalProjectsWeight = value; }
        public byte HowManyMonthPior { get => _HowManyMonthPior; set => _HowManyMonthPior = value; }

        #endregion Properiets

        #region PublicMethods

        public async Task<(int? id, string fullName)> FindIdMostFreeDeveloperAsync(List<Project> projects)
        {
            var currentTime = DateTime.UtcNow;
            var lastTwoWeeks = DateTime.UtcNow.AddDays(-14);
            var beginOfPeriod = DateTime.UtcNow.AddMonths(-HowManyMonthPior);

            projects = projects.FindAll(t => t.DevTeam == _LookInDevTeam.Id && t.SubmitionTime > beginOfPeriod);

            var devStatsList = GetDevStatsList(projects, lastTwoWeeks, currentTime);

            if (devStatsList.Count == 0) return (id: null, fullName: string.Empty);

            return await GetUnluckyDev(devStatsList);
        }

        #endregion PublicMethods

        public async Task<List<DevStats>> GetListOfDevStats(List<Project> projects)
        {
            var currentTime = DateTime.UtcNow;
            var lastTwoWeeks = DateTime.UtcNow.AddDays(-14);
            var beginOfPeriod = DateTime.UtcNow.AddMonths(-HowManyMonthPior);

            projects = await Task.Run(() => projects.FindAll(t => t.DevTeam == _LookInDevTeam.Id && t.SubmitionTime > beginOfPeriod));

            return GetDevStatsList(projects, lastTwoWeeks, currentTime);
        }

        #region Private Methods

        private async Task<(int? id, string fullName)> GetUnluckyDev(List<DevStats> list)
        {
            (int? userId, double score, DateTime updateTime, string name) winner = (null, 9999, DateTime.UtcNow, string.Empty);
            foreach (var item in list)
            {
                if (winner.score == item.Score && winner.updateTime < item.LastUpdate)
                    winner = (item.DevId, item.Score, item.LastUpdate, item.FullName);
                else if (winner.score > item.Score) winner = (item.DevId, item.Score, item.LastUpdate, item.FullName);
            }
            return await Task.Run(function: () => (id: winner.userId, fullName: winner.name));
        }

        private List<DevStats> GetDevStatsList(List<Project> projects, DateTime lastTwoWeeks,
                                                           DateTime currentTime)
        {
            var tempDevStatList = new List<DevStats>();

            foreach (var dev in _LookInDevTeam.Employee)
            {
                var devStat = new DevStats(dev.Id);
                devStat.FullName = $"{dev.EmpName} { dev.EmpSurname}";
                devStat.Project = projects.Count(d => d.Developer == devStat.DevId);
                devStat.ProjectAfterDeadline = projects.Count(d => d.Developer == devStat.DevId && d.DueDate < currentTime);
                devStat.CriticalProjectsWithTwoWeeksDeadline =
                        projects.Count(d => d.Developer == devStat.DevId && d.DueDate > lastTwoWeeks && d.Piority.ToLower().Equals("critical"));

                var res = from p in projects
                          where p.Developer == devStat.DevId
                          orderby p.UpdateTime ascending
                          select p.UpdateTime;
                try
                {
                    devStat.LastUpdate = (DateTime)res.Last();
                }
                catch (Exception)
                {
                    devStat.LastUpdate = DateTime.MinValue;
                }
                devStat.Score = (devStat.Project * NormalWeight) + (devStat.ProjectAfterDeadline * AfterDeadlineWeight)
                               + (devStat.CriticalProjectsWithTwoWeeksDeadline + CriticalProjectsWeight);
                tempDevStatList.Add(devStat);
            }
            return tempDevStatList;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _LookInDevTeam = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Private Methods
    }
}