using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Api
{
    public interface IValidatorsService
    {
        Task<IEnumerable<ValidatorNode>> GetAllValidatorsAsync();
    }
}
