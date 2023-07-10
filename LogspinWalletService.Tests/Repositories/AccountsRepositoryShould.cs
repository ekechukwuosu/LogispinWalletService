using LogispinWalletService.DAL.Repository.Implementation;
using LogispinWalletService.Data.Models;
using LogspinWalletService.Tests.Utility;
using LogspinWalletService.Tests.Utility.FakeDBContexts;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace LogspinWalletService.Tests.Repositories
{
    public class AccountsRepositoryShould
    {
        private readonly AccountRepository _accountRepository;
        public AccountsRepositoryShould()
        {
            var _appDBContext = new Mock<FakeDBContexts>();
            var _logger = new Mock<ILogger<AccountRepository>>();
            _accountRepository = new AccountRepository(_appDBContext.Object.GetDatabaseContext().Result, _logger.Object);
        }
        [Fact]
        public async void CreateAccount_Should_Return_Account()
        {
            var parameters = TestRequestParameters.GetSampleCreateAccountRequest();
            var result = await _accountRepository.CreateAccount(parameters.FirstName, parameters.LastName, parameters.Email);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Account>(result);
        }
        [Fact]
        public async void GetAccountDetailsWithEmail_Should_Return_Account()
        {
            var parameters = TestRequestParameters.GetSampleGetWalletAccountDetailsRequest();
            var result = await _accountRepository.GetAccountDetailsWithEmail(parameters.Email);

            var expectedResponse = JsonConvert.SerializeObject(TestResponses.GetSampleAccount());
            var actualResponse = JsonConvert.SerializeObject(result);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Account>(result);
            Assert.True(expectedResponse.Equals(actualResponse));
        }

        [Fact]
        public async void GetAccountDetailsWithAccountId_Should_Return_Account()
        {
            var accountId = TestRequestParameters.GetSampleAccountId();
            var result = await _accountRepository.GetAccountDetailsWithAccountId(accountId);

            var expectedResponse = JsonConvert.SerializeObject(TestResponses.GetSampleAccount());
            var actualResponse = JsonConvert.SerializeObject(result);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Account>(result);
            Assert.True(expectedResponse.Equals(actualResponse));
        }
        [Fact]
        public async void GetAccountIdWithEmail_Should_Return_AccountId()
        {
            var parameters = TestRequestParameters.GetSampleGetWalletAccountDetailsRequest();
            var result = await _accountRepository.GetAccountId(parameters.Email);

            Assert.IsAssignableFrom<Guid>(result);
            Assert.True(TestResponses.GetSampleAccount().Id.Equals(result));
        }
        [Fact]
        public async void CheckIfAccountExists_Should_Return_Bool_Exists()
        {
            var parameters = TestRequestParameters.GetSampleGetWalletAccountDetailsRequest();
            var result = await _accountRepository.CheckIfAccountExists(parameters.Email);

            Assert.IsAssignableFrom<bool>(result);
            Assert.True(result);
        }
        [Fact]
        public async void CheckIfAccountExists_Should_Return_Bool_NotExists()
        {
            var parameters = TestRequestParameters.GetSampleNotPresentEmail();
            var result = await _accountRepository.CheckIfAccountExists(parameters);

            Assert.IsAssignableFrom<bool>(result);
            Assert.False(result);
        }
    }
}
