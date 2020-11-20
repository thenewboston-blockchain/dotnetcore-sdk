using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Models;

namespace Thenewboston.Validator.Api
{
    public interface IValidatorsService
    {
        Task<PaginatedResponseModel> GetAllValidatorsAsync();
    }
}
