using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public interface IValidatorService
    {
        Task<ResponseModel> GetAllValidatorsAsync();

        Task<ValidatorNode> PatchValidatorAsync(string nodeIdentifier, RequestModel trust);

    }
}
