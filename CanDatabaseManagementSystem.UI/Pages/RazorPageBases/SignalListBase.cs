using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;
using Microsoft.AspNetCore.Components;

namespace CanDatabaseManagementSystem.UI.Pages.RazorPageBases
{
    public class SignalListBase : ComponentBase
    {
        [Inject]
        public ISignalService _signalService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string messageId { get; set; }
        [Parameter]
        public string dbcFileId { get; set; }
        protected List<SignalDto> signals { get; set; }
        protected override async Task OnInitializedAsync()
        {
            signals = await _signalService.GetSignals(int.Parse(messageId));
        }
        protected void Close()
        {
            _navigationManager.NavigateTo("/MessageList/" + int.Parse(dbcFileId));
        }
    }
}
