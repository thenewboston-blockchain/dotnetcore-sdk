using System.Threading.Tasks;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Api
{
    public interface IValidatorConfirmationBlockService
    {
        Task<ConfirmationBlockResponse> PostConfirmationBlockAsync(ConfirmationBlock confirmationBlockMessage);
        Task<ConfirmationBlock> GetQueuedConfirmationBlockAsync(string blockIdentifier);
        Task<ConfirmationBlock> GetValidConfirmationBlockAsync(string blockIdentifier); 
    }
}
