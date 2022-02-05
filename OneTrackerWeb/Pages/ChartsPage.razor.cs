using System.Threading.Tasks;

namespace OneTrackerWeb.Pages
{
    public partial class ChartsPage
    {
        protected override async Task OnInitializedAsync()
        {
            if (BindingContext.Toaster is null) await Task.Run(() => BindingContext.Toaster = Toaster);
        }
    }
}