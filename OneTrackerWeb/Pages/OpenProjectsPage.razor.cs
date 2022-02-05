using DbDataLibrary.Models.Entities;
using Syncfusion.Blazor.Grids;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Pages
{
    public partial class OpenProjectsPage
    {
        private List<Project> _pageRecordList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BindingContext.Toaster = Toaster;
            await LoadMainTable();
        }

        private async Task LoadMainTable() => _pageRecordList = await BindingContext.LoadMainViewTable();

        public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "GridTeams_Refresh")
            {
                await LoadMainTable();
            }
            else if (args.Item.Id == "GridTeams_delete")
            {
                await BindingContext.DeletetemToDb();
            }
            else if (args.Item.Id == "GridTeams_edit")
            {
                //_dev = await BindingContext.ConvertToDisplayClass(BindingContext.WorkItem);
                BindingContext.IsNew = false;
            }
            else if (args.Item.Id == "GridTeams_cancel")
            {
                //_dev = new();
                BindingContext.ClearAfterEdit();
            }
        }

        public void RowSelectingHandler(RowSelectEventArgs<Project> args) => BindingContext.WorkItem = args.Data;

        public void RowDeselectingHandler(RowDeselectEventArgs<Project> args) => BindingContext.WorkItem = null;
    }
}