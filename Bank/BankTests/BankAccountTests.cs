using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00; // Maior que o saldo
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            string expectedErrorMessage = "Specified argument was out of the range of valid values. (Parameter 'amount')"; // Mensagem de erro atualizada

            // Act and assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            StringAssert.Contains(exception.Message, expectedErrorMessage);
        }
    }
}
