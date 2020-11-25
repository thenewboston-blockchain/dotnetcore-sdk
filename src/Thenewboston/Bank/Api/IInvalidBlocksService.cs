using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Thenewboston.Bank.Models;

namespace Thenewboston.Bank.Api
{
    public interface IInvalidBlocksService
    {
        Task<IEnumerable<BankInvalidBlock>> GetInvalidBankBlocksAsync();
        Task<BankInvalidBlock> SendInvalidBlocksToBankAsync(BankInvalidBlockRequest model);
        
    }
}