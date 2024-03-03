using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;
using Microsoft.AspNetCore.Components;

namespace CanDatabaseManagementSystem.UI.Pages.RazorPageBases
{
    public class MessageListBase : ComponentBase
    {
        [Inject]
        public IMessageService _messageService {  get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string dbcFileId {  get; set; }
        protected List<MessageDto> messages { get; set; }
        protected override async Task OnInitializedAsync()
        {
            messages = await _messageService.GetMessages(int.Parse(dbcFileId));
        }
        protected void Close()
        {
            _navigationManager.NavigateTo("/");
        }
    }
}
