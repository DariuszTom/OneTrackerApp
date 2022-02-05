using DbDataLibrary.Models.Entities;
using Syncfusion.Blazor.Grids;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Pages
{
    public partial class CloseProjectsPage
    {
        private SfGrid<ProjectFinalized> Grid;
        private List<ProjectFinalized> _pageRecordList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BindingContext.Toaster = Toaster;
            await LoadMainTable();
        }

        private async Task LoadMainTable() => _pageRecordList = await BindingContext.LoadMainViewTable();

        public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id == "Grid_Refresh")
            {
                await LoadMainTable();
            }
            else if (args.Item.Id == "Grid_pdfexport")
            {
                await this.Grid.PdfExport();
            }
            else if (args.Item.Id == "Grid_excelexport")
            {
                await this.Grid.ExcelExport();
            }
        }
    }
}