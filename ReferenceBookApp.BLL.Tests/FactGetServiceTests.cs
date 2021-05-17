using System;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using AutoFixture;
using NUnit.Framework;
using ReferenceBookApp.BLL.Implementation;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Contracts;


namespace ReferenceBookApp.BLL.Tests
{
    public class FactGetServiceTests
    {
        [Test]
        public async Task GetAsync_DoesNothing()
        {
            //arrange
            var factIdentity = new Mock<IFactIdentity>();

            var fact = new Fact();
            var factDataAccess = new Mock<IFactDataAccess>();
            factDataAccess.Setup(x => x.GetAsync(factIdentity.Object)).ReturnsAsync(fact);

            var factGetService = new FactGetService(factDataAccess.Object);

            //act
            var action = new Func<Task>(() => factGetService.GetAsync(factIdentity.Object));

            //assert
            action.Should().NotBeNull();
        }
    }
}