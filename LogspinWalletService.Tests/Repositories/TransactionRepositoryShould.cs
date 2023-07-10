using LogispinWalletService.Common.Enums;
using LogispinWalletService.DAL.Repository.Implementation;
using LogispinWalletService.DAL.Repository.Interfaces;
using LogispinWalletService.Data.Models;
using LogspinWalletService.Tests.Utility;
using LogspinWalletService.Tests.Utility.FakeDBContexts;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace LogspinWalletService.Tests.Repositories
{
    public class TransactionRepositoryShould
    {
        private readonly TransactionRepository _transactionRepository;
        public TransactionRepositoryShould()
        {
            var _appDBContext = new Mock<FakeDBContexts>();
            var _logger = new Mock<ILogger<TransactionRepository>>();
            _transactionRepository = new TransactionRepository(_appDBContext.Object.GetDatabaseContext().Result, _logger.Object);
        }
        [Fact]
        public async void LogTransaction_Should_Return_Transaction()
        {
            var parameters = TestRequestParameters.GetSampleAccountId();
            var result = await _transactionRepository.LogTransaction(parameters, 1000, TransactionType.Add);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Transaction>(result);
            Assert.False(new Guid().Equals(result.Id));
        }
        [Fact]
        public async void GetFailedTransactionCount_Should_Equal_FakeDBDetails()
        {
            var parameters = TestRequestParameters.GetSampleAccountId();
            var result = await _transactionRepository.GetFailedTransactionsCount(parameters);

            Assert.IsAssignableFrom<int>(result);
            Assert.Equal(1, result);
            Assert.NotEqual(17, result);
        }
        [Fact]
        public async void GetPendingTransactionCount_Should_Equal_FakeDBDetails()
        {
            var parameters = TestRequestParameters.GetSampleAccountId();
            var result = await _transactionRepository.GetPendingTransactionsCount(parameters);

            Assert.IsAssignableFrom<int>(result);
            Assert.Equal(0, result);
            Assert.NotEqual(5, result);
        }
        [Fact]
        public async void GetSuccessTransactionCount_Should_Equal_FakeDBDetails()
        {
            var parameters = TestRequestParameters.GetSampleAccountId();
            var result = await _transactionRepository.GetSuccessfulTransactionsCount(parameters);

            Assert.IsAssignableFrom<int>(result);
            Assert.Equal(1, result);
            Assert.NotEqual(0, result);
        }
        [Fact]
        public async void GetTransactions_Should_Return_Paginated_Transaction()
        {
            var parameters = TestRequestParameters.GetSampleAccountId();
            var result = await _transactionRepository.GetTransactions(parameters, 1, 2);

            var expectedResponse = JsonConvert.SerializeObject(TestResponses.GetSampleTransactionList());
            var actualResponse = JsonConvert.SerializeObject(result);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<Transaction>>(result);
            Assert.True(expectedResponse.Equals(actualResponse));
        }
        [Fact]
        public async void GetTransactionsWithAccountIdAndStatus_Should_Return_Paginated_Transaction()
        {
            var parameters = TestRequestParameters.GetSampleAccountId();
            var result = await _transactionRepository.GetTransactionsByAccountIdAndStatus(parameters, TransactionStatus.Success, false, 1, 2);

            var expectedResponse = JsonConvert.SerializeObject(TestResponses.GetSampleSingleTransactionInList());
            var actualResponse = JsonConvert.SerializeObject(result);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<Transaction>>(result);
            Assert.True(expectedResponse.Equals(actualResponse));
        }
    }
}
