using System.Threading.Tasks;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Api
{
    internal interface IValidatorConfirmationBlockService
    {
        Task<ConfirmationBlockResponse> PostConfirmationBlockAsync(ConfirmationBlock confirmationBlockMessage);
        Task<ConfirmationBlock> GetQueuedConfirmationBlockAsync(string blockIdentifier);
        Task<ConfirmationBlock> GetValidConfirmationBlockAsync(string blockIdentifier); 
    }
}
