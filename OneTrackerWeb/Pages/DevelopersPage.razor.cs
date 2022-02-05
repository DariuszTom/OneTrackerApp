using DbDataLibrary.Models.DisplayModel;
using DbDataLibrary.Models.Entities;
using Syncfusion.Blazor.Grids;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Pages
{
    public partial class DevelopersPage
    {
        private List<Employee> _pageRecordList { get; set; }
        private DevelopertDisplay _dev { get; set; }
        private string[] _SingleSelected;

        public string[] SingleSelected
        {
            get
            {
                if (_SingleSelected is null)
                {
                    _SingleSelected = new string[] { _dev.Position is null ? "A1" : _dev.Position };
                }
                return _SingleSelected;
            }
            set
            {
                _SingleSelected = value;
                _dev.Position = _SingleSelected[0];
            }
        }

        protected override async Task OnInitializedAsync()
        {
            BindingContext.Toaster = Toaster;
            _dev = new();
            await LoadMainTable();
        }

        private async Task LoadMainTable() => _pageRecordList = await BindingContext.LoadMainViewTable();

        private async Task AddEntity()
        {
            await BindingContext.ConvertAndAdd(_dev);
            await LoadMainTable();
            _dev = new();
        }

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
                BindingContext.ButtonTxt = "Edit";
                _dev = await BindingContext.ConvertToDisplayClass(BindingContext.WorkItem);
                BindingContext.IsNew = false;
            }
            else if (args.Item.Id == "GridTeams_cancel")
            {
                _dev = new();
                BindingContext.ClearAfterEdit();
            }
        }

        public void RowSelectingHandler(RowSelectEventArgs<Employee> args) => BindingContext.WorkItem = args.Data;

        public void RowDeselectingHandler(RowDeselectEventArgs<Employee> args) => BindingContext.WorkItem = null;
    }
}