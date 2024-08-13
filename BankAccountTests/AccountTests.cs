﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new Account("J Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod] // shortcut: testm
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert
            // Arrange
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add here 

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
        }

        // Withdrawing a positive amount - returns updated balance
        // Withdrawing 0 - Throws ArgumentOutOfRange exception
        // Withdrawing negative amount - Throws ArgumentOutOfRange exception
        // Withdrawing more than available balance - ArgumentException
        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            //Arrange
            double initialDeposit = 100;
            double withdrawlAmount = 50;
            double expectedBalance = initialDeposit - withdrawlAmount;

            //Act
            acc.Deposit(initialDeposit);
            acc.WithDraw(withdrawlAmount);

            double actualBalance = acc.Balance;

            //Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }
}