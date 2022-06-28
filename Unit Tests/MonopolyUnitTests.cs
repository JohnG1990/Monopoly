using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonopolyTests
{
    [TestClass]
    public class MonopolyUnitTests
    {
        [TestMethod]
        public void DiceRollTest()
        {
            Monopoly.Dice dice = new Monopoly.Dice();
            int roll = dice.RollDice();
            Assert.IsTrue((roll >= 1 && roll <= 6));
        }
    }
}
