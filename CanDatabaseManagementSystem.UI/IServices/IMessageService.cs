using CanDatabaseManagementSystem.Common.DtoModels;

namespace CanDatabaseManagementSystem.UI.IServices
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessages(int dbcFileId);
    }
}
