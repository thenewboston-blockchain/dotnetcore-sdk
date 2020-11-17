using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thenewboston.Common.Models;

namespace Thenewboston.Bank.Api
{
    public interface IValidatorService
    {
        Task<IEnumerable<ValidatorNode>> GetAllValidatorsAsync();
    }
}
