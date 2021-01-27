using System;
using Xunit;

namespace DesafioVerticore.Tests
{
    public class CalculateAgeTest
    {
        [Fact]
        public void TestAgeDifferenceNormalYear()
        {
            DateTime birthDate = new DateTime(1996, 12, 14);
            var ageDifference = Program.CalcularIdade(birthDate, new DateTime(2021, 01, 27));
            Assert.Equal("24 ano(s), 1 mês(es) e 13 dia(s).", ageDifference);
        }

        [Fact]
        public void TestAgeDifferenceLeapYear()
        {
            DateTime birthDate = new DateTime(2020, 02, 29);
            var ageDifference = Program.CalcularIdade(birthDate, new DateTime(2021, 03, 01));
            Assert.Equal("1 ano(s), 0 mês(es) e 1 dia(s).", ageDifference);
        }

        [Fact]
        public void TestAgeDifferenceWhithoutYear()
        {
            DateTime birthDate = new DateTime(2020, 03, 08);
            var ageDifference = Program.CalcularIdade(birthDate, new DateTime(2020, 05, 01));
            Assert.Equal("0 ano(s), 1 mês(es) e 23 dia(s).", ageDifference);
        }

        [Fact]
        public void TestAgeDifferenceWhithoutDay()
        {
            DateTime birthDate = new DateTime(2020, 02, 29);
            var ageDifference = Program.CalcularIdade(birthDate, new DateTime(2024, 02, 29));
            Assert.Equal("4 ano(s), 0 mês(es) e 0 dia(s).", ageDifference);
        }
    }
}
