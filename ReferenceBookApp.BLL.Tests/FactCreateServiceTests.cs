using System;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using NUnit.Framework;
using AutoFixture;
using ReferenceBookApp.BLL.Contracts;
using ReferenceBookApp.BLL.Implementation;
using ReferenceBookApp.DataAccess.Contracts;
using ReferenceBookApp.Domain;
using ReferenceBookApp.Domain.Models.Update;

namespace ReferenceBookApp.BLL.Tests
{
    public class FactCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_FieldValidationSucceed_CreatesFact()
        {
            //arrange
            var fact = new FactUpdateModel();
            var expected = new Fact();

            var fieldGetService = new Mock<IFieldGetService>();
            fieldGetService.Setup(x => x.ValidateAsync(fact));

            var factDataAccess = new Mock<IFactDataAccess>();
            factDataAccess.Setup(x => x.InsertAsync(fact)).ReturnsAsync(expected);

            var factGetService = new FactCreateService(factDataAccess.Object, fieldGetService.Object);

            //act
            var result = await factGetService.CreateAsync(fact);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_FieldValidationFailed_ThrowsError()
        {
            //arrange
            var fixture = new Fixture();
            var fact = new FactUpdateModel();
            var expected = fixture.Create<string>();

            var fieldGetService = new Mock<IFieldGetService>();
            fieldGetService.Setup(x => x.ValidateAsync(fact)).Throws(new InvalidOperationException(expected));

            var factDataAccess = new Mock<IFactDataAccess>();

            var factGetService = new FactCreateService(factDataAccess.Object, fieldGetService.Object);

            //act
            var action = new Func<Task>(() => factGetService.CreateAsync(fact));

            //assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            factDataAccess.Verify(x => x.InsertAsync(fact), Times.Never);
        }
    }
}