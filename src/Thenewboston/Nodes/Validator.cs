using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thenewboston.Common.Http;
using Thenewboston.Common.Models;
using Thenewboston.Validator.Api;
using Thenewboston.Validator.Api.Models;
using Thenewboston.Validator.Models;

namespace Thenewboston.Nodes
{
    public class Validator
    {
        private readonly IAccountsService _accountsService;
        private readonly IConfigService _configService;
        private readonly IValidatorConfirmationBlockService _validatorConfirmationBlockService;
        private readonly IValidatorsService _validatorsService;

        public Validator(string ip, int port)
        {
            var requestSender = new SimpleHttpRequestSender($"{ip}:{port}");
            _accountsService = new AccountsService(requestSender);
            _configService = new ConfigService(requestSender);
            _validatorConfirmationBlockService = new ValidatorConfirmationBlockService(requestSender);
            _validatorsService = new ValidatorsService(requestSender);
        }

        public async Task<IEnumerable<ValidatorAccount>> GetAccounts(int offset = 0, int limit = 10)
        {
            var result = await _accountsService.GetAccountsAsync(offset, limit);
            return result.Results;
        }
        
        public async Task<ValidatorAccountBalance> GetAccountBalance(string accountNumber)
        {
            var result = await _accountsService.GetAccountBalanceAsync(accountNumber);
            return result;
        }
        
        public async Task<ValidatorAccountBalanceLock> GetAccountBalanceLock(string accountNumber)
        {
            var result = await _accountsService.GetAccountBalanceLockAsync(accountNumber);
            return result;
        }

        public async Task<ValidatorConfig> GetValidatorConfig()
        {
            var result = await _configService.GetValidatorConfigAsync();
            return result;
        }

        public async Task<ConfirmationBlock> GetQueuedConfirmationBlock(string blockIdentifier)
        {
            var result = await _validatorConfirmationBlockService.GetQueuedConfirmationBlockAsync(blockIdentifier);
            return result;
        }

        public async Task<ConfirmationBlock> GetValidConfirmationBlock(string blockIdentifier)
        {
            var result = await _validatorConfirmationBlockService.GetValidConfirmationBlockAsync(blockIdentifier);
            return result;
        }

        public async Task<IEnumerable<ValidatorResponseModel>> GetAllValidators(int offset, int limit)
        {
            var result = await _validatorsService.GetAllValidatorsAsync(offset, limit);
            return result.Results;
        }
    }
}