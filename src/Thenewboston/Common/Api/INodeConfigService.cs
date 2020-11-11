using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Thenewboston.Common.Api
{
    public interface INodeConfigService
    {
        Task<T> GetConfigAsync<T>();
    }
}
