using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedLibrary.Developer
{
    public class DeveloperStatsHelper : IDisposable
    {
        #region Constructor

        public DeveloperStatsHelper(int teamId)
        {
            _TeamId = teamId;
            _caseService = new SpecialCaseService();
        }

        #endregion Constructor

        #region Fields

        private readonly int _TeamId;
        private bool _disposedValue;
        private SpecialCaseService _caseService;

        #endregion Fields

        #region Methods

        public async Task<List<DevStats>> GetDevStats()
        {
            var team = await GetTeam();
            var projects = await _caseService.GetAllOpenProjects();

            if (team is null || projects is null) return null;

            using (var perfomanceCheck = new FindFreeDeveloper(team))
            {
                perfomanceCheck.HowManyMonthPior = 12;
                var devStats = await perfomanceCheck.GetListOfDevStats(projects);
                devStats.Sort();
                return devStats;
            }
        }

        private async Task<DevTeam> GetTeam()
        {
            if (_TeamId == 0) return null;

            return await _caseService.GetDevTeamById(_TeamId);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _caseService = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DeveloperStatsHelper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Methods
    }
}