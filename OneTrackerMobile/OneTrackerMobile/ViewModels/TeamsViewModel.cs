using AsyncAwaitBestPractices.MVVM;
using DbDataLibrary.Mapper;
using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using OneTrackerMobile.Services;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using OneTrackerMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels
{
    public class TeamsViewModel : AllViewModel<TeamForViewNew>
    {
        #region Constructor

        public TeamsViewModel() : base()
        {
            base.Title = "Teams";
            Task.Run(() => base.LoadMainViewTable());
        }

        #endregion Constructor

        #region Commands

        private AsyncCommand<TeamForViewNew> _DeleteItem;
        public AsyncCommand<TeamForViewNew> DeleteItem { get => _DeleteItem = new AsyncCommand<TeamForViewNew>((obj) => DeleteTeam(obj)); }

        private AsyncCommand<TeamForViewNew> _EditItem;
        public AsyncCommand<TeamForViewNew> EditItem { get => _EditItem = new AsyncCommand<TeamForViewNew>((obj) => EditTeam(obj)); }

        #endregion Commands

        #region Methods

        public override async Task OnNewItem()
        {
            await Shell.Current.GoToAsync(nameof(NewTeamPage));
        }

        private async Task EditTeam(TeamForViewNew team)
        {
            if (team is null) return;

            using (var mpConfig = new AutoMaperConfig())
            {
                var mapperNew = mpConfig.MyMapperConfig.CreateMapper();
                DevTeam devTeam = mapperNew.Map<DevTeam>(team);
                var service = DependencyService.Get<IDataStore<DevTeam>>();

                var addPage = new NewTeamPage
                {
                    BindingContext = new NewTeamViewModel(devTeam)
                };
                await Shell.Current.Navigation.PushAsync(addPage);
            }
        }

        private async Task DeleteTeam(TeamForViewNew team)
        {
            if (team is null) return;
            var service = DependencyService.Get<IDataStore<DevTeam>>();
            bool isSucces = await service.DeleteItemAsync(team.Id);
            string infoOfOperation = isSucces ? $"Done, {team.TeamName} was remove from database" :
                                     $"Error unable to delete team {team.TeamName} ";
            await base.ShowMsgBox($"Status:{infoOfOperation}");
            base.RemoveIdItemFormMainList();
        }

        #endregion Methods
    }
}