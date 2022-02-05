using DbDataLibrary.Models.DisplayModel;
using MatBlazor;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace OneTrackerWeb.Pages
{
    public partial class AddProject
    {
        private ProjectDisplay _pro { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _pro = new();
            if (BindingContext.Toaster is null) await Task.Run(() => BindingContext.Toaster = Toaster);
        }

        private async Task AddEntity()
        {
            await BindingContext.ConvertAndAdd(_pro);
            _pro = new();
        }

        private void Clear(MouseEventArgs e) => _pro = new();

        private async Task FindDev(MouseEventArgs e)
        {
            if (_pro.DevTeam == 0 || _pro.DevTeam is null)
            {
                Toaster.Add("Dev team not selected", MatToastType.Warning);
                return;
            }
            int? res = await BindingContext.FindFreeDev((int)_pro.DevTeam);
            _pro.Developer = res;
        }
    }
}