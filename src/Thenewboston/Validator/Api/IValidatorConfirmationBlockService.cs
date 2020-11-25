using System.Threading.Tasks;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Api
{
    public interface IValidatorConfirmationBlockService
    {
        Task<ConfirmationBlockResponse> PostConfiramtionBlockAsync(ConfirmationBlock confirmationBlockMessage);
        Task<ConfirmationBlock> GetQueuedConfiramtionBlockAsync(string blockIdentifier);
        Task<ConfirmationBlock> GetValidConfirmationBlockAsync(string blockIdentifier); 
    }
}
