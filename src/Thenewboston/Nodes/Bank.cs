using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thenewboston.Bank.Api;
using Thenewboston.Bank.Api.Models;
using Thenewboston.Bank.Models;
using Thenewboston.Common.Api.Models;
using Thenewboston.Common.Http;

namespace Thenewboston.Nodes
{
    public class Bank
    {
        private readonly IAccountsService _accountsService;
        private readonly IBankConfirmationBlockService _bankConfirmationBlockService;
        private readonly IBlocksService _blocksService;
        private readonly IConfigService _configService;
        private readonly IConnectedBanksService _banksService;
        private readonly ITransactionsService _transactionsService;
        private readonly IValidatorConfirmationService _validatorConfirmationService;
        private readonly IValidatorService _validatorService;

        public Bank(string ip, int port)
        {
            var requestSender = new SimpleHttpRequestSender($"{ip}:{port}");
            _accountsService = new AccountsService(requestSender);
            _bankConfirmationBlockService = new BankConfirmationBlockService(requestSender);
            _blocksService = new BlocksService(requestSender);
            _configService = new ConfigService(requestSender);
            _banksService = new ConnectedBanksService(requestSender);
            _transactionsService = new TransactionsService(requestSender);
            _validatorConfirmationService = new ValidatorConfirmationService(requestSender);
            _validatorService = new ValidatorService(requestSender);
        }

        public async Task<IEnumerable<BankAccount>> GetAccounts(
            int offset = 0,
            int limit = 10)
        {
            var result = await _accountsService.GetAccountsAsync(offset, limit);
            return result.Results;
        }

        public async Task<BankAccount> UpdateBankAccount(
            string accountNumber,
            double trust,
            string nodeIdentifier,
            string signature)
        {
            var requestModel = new RequestModel
            {
                Message = new Message
                {
                    Trust = trust
                },
                NodeIdentifier = nodeIdentifier,
                Signature = signature
            };

            var result = await _accountsService.UpdateAccountAsync(accountNumber, requestModel);

            return result;
        }

        public async Task<IEnumerable<BankConfirmationBlock>> GetBankConfirmationBlocks(
            int offset = 0,
            int limit = 10)
        {
            var result = await _bankConfirmationBlockService.GetAllBankConfiramtionBlocksAsync(offset, limit);
            return result.Results;
        }

        public async Task<IEnumerable<BankBlock>> GetBankBlocks(
            int offset = 0,
            int limit = 10)
        {
            var result = await _blocksService.GetBlocksAsync(offset, limit);
            return result.Results;
        }

        public async Task<BankBlock> CreateBlock(Common.Models.Block block)
        {
            var result = await _blocksService.PostBlocksAsync(block);
            return result;
        }

        public async Task<BankConfig> GetBankConfig()
        {
            var result = await _configService.GetBankConfigAsync();
            return result;
        }

        public async Task<IEnumerable<BankNode>> GetConnectedBanks(
            int offset = 0,
            int limit = 10)
        {
            var result = await _banksService.GetBanksAsync(offset, limit);
            return result.Results;
        }

        public async Task<IEnumerable<BankTransaction>> GetTransactions(
            int offset = 0,
            int limit = 10)
        {
            var result = await _transactionsService.GetAllTransactionsAsync(offset, limit);
            return result.Results;
        }

        public async Task<IEnumerable<ValidatorConfirmation>> GetValidatorConfirmationServices(
            int offset = 0,
            int limit = 10)
        {
            var result = await _validatorConfirmationService.GetValidatorConfirmationServicesAsync(offset, limit);
            return result.Results;
        }

        public async Task<IEnumerable<BankValidator>> GetValidators(
            int offset = 0,
            int limit = 10)
        {
            var result = await _validatorService.GetAllValidatorsAsync(offset, limit);
            return result.Results;
        }

    }
}
