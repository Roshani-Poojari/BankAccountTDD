namespace AccountXUnitTest
{
    public class UnitTest1
    {
        Account _account;
        public UnitTest1()
        {
            _account = new Account();
        }

        [Fact]
        public void DepositValidAmount_1000_GiveExpectedResult_1000()
        {
            double amount = 1000;
            double expectedResult = 1000;
            _account.Deposit(amount);
            double actualResult = _account.GetBalance();
            Assert.Equal(expectedResult, expectedResult);
        }

        [Fact]
        public void WithdrawValidAmount_100_GiveExpectedResult_900()
        {
            double depositAmount = 1000;
            _account.Deposit(depositAmount);
            double withdrawAmount = 100;
            double expectedResult = 900;
            _account.Withdraw(withdrawAmount);
            double actualResult = _account.GetBalance();
            Assert.Equal(actualResult, expectedResult);
        }
        
        [Fact]
        public void TransferToValidAccountGiveExpectedResultAmountTransferedSuccessfully()
        {
            double depositAmount = 1000;
            _account.Deposit(depositAmount);
            double transferAmount = 400;
            double expectedResult = 400;
            Account toAccount = new Account();
            _account.Transfer(toAccount, transferAmount);
            double actualResult = toAccount.GetBalance();
            Assert.Equal(actualResult, expectedResult);

        }
        
        [Fact]
        public void DepositInValidAmountNegative_1000_GiveExpectedResultException()
        {
            double amount = -1000;
            Assert.Throws<ArgumentException>(() => _account.Deposit(amount));
        }

        [Fact]
        public void WithdrawNegativeAmountNegative_1000_GiveExpectedResultException()
        {
            double depositAmount = 1000;
            _account.Deposit(depositAmount);
            double amount = -1000;
            Assert.Throws<ArgumentException>(() => _account.Withdraw(amount));
        }

        [Fact]
        public void WithdrawInValidAmountNegative_1000_GiveExpectedResultException()
        {
            double depositAmount = 1000;
            _account.Deposit(depositAmount);
            double amount = 2000;
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(amount));
        }

        [Fact]
        public void TransferToInValidAccountGiveExpectedResultException()
        {
            double depositAmount = 1000;
            _account.Deposit(depositAmount);
            double amount = 400;
            Account toAccount = null;
            Assert.Throws<ArgumentNullException>(() => _account.Transfer(toAccount, amount));
        }
    }
}