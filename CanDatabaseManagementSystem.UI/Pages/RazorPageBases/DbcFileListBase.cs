using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CanDatabaseManagementSystem.UI.Pages.RazorPageBases
{
    public class DbcFileListBase : ComponentBase
    {
        [Inject]
        public IDbcFileService _dbcFileService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        protected List<DbcFileDto> dbcFiles { get; set; }
		protected override async Task OnInitializedAsync()
        {
            dbcFiles = await _dbcFileService.GetDbcFiles();
        }
        protected void OpenMessageListPage(int dbcFileId)
        {
            _navigationManager.NavigateTo("MessageList/" + dbcFileId);
        }
        protected async Task UploadDbcFile(InputFileChangeEventArgs e)
        {
            var dbcFileData = new DbcFileData();
            foreach (var file in e.GetMultipleFiles(1))
            {
                await using var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);
                var byteArray = memoryStream.ToArray();
                dbcFileData.Data = System.Text.Encoding.Default.GetString(byteArray);
                dbcFileData.FileName = file.Name;
            }
            await _dbcFileService.UploadDbcFile(dbcFileData);
            dbcFiles = await _dbcFileService.GetDbcFiles();
        }
    }
}
