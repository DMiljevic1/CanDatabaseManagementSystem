using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;
using Microsoft.AspNetCore.Components;

namespace CanDatabaseManagementSystem.UI.Pages.RazorPageBases
{
    public class DbcFileListBase : ComponentBase
    {
        [Inject]
        public IDbcFileService _dbcFileService { get; set; }
        protected List<DbcFileDto> dbcFiles { get; set; }
        protected List<MessageDto> messages { get; set; }
		protected override async Task OnInitializedAsync()
        {
            dbcFiles = await _dbcFileService.GetDbcFiles();
        }
    }
}
