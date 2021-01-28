using Autofac;
using Doorman.DataServices;
using Doorman.StartUp;
using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Doorman.Model;
using Doorman.Helpers;

namespace Doorman.Tests
{
    public class IntExtensionsTests
    {
        [Fact]
        public void ShouldReturnThreeInitialZero ()
        {
            int i = 1;
            string numberWithInitialZZeros= i.InitialNextIdWithZeros();
            Assert.Equal("0002", numberWithInitialZZeros);
        }

        [Fact]
        public void ShouldReturnTwoInitialZero()
        {
            int i = 34;
            string numberWithInitialZZeros = i.InitialNextIdWithZeros();
            Assert.Equal("0035", numberWithInitialZZeros);
        }

        [Fact]
        public void ShouldReturnNumberAsAString()
        {
            int i = 1234;
            string numberWithInitialZZeros = i.InitialNextIdWithZeros();
            Assert.Equal("1235", numberWithInitialZZeros);
        }

    }
}
