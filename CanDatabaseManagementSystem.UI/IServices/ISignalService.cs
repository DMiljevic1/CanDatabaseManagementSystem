using CanDatabaseManagementSystem.Common.DtoModels;

namespace CanDatabaseManagementSystem.UI.IServices
{
    public interface ISignalService
    {
        Task<List<SignalDto>> GetSignals(int messageId); 
    }
}
