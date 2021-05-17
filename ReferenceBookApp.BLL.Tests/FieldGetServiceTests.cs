using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
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
    [TestFixture]
    public class FieldGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_FieldExists_DoesNothing()
        {
            //arrange
            var fieldContainer = new Mock<IFieldContainer>();

            var field = new Field();
            var fieldDataAccess = new Mock<IFieldDataAccess>();
            fieldDataAccess.Setup(x => x.GetByAsync(fieldContainer.Object)).ReturnsAsync(field);

            var fieldGetService = new FieldGetService(fieldDataAccess.Object);

            //act
            var action = new Func<Task>(() => fieldGetService.ValidateAsync(fieldContainer.Object));

            //assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_FieldNotExists_ThrowsError()
        {
            //arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var fieldContainer = new Mock<IFieldContainer>();
            fieldContainer.Setup(x => x.FieldId).Returns(id);

            var field = new Field();
            var fieldDataAccess = new Mock<IFieldDataAccess>();
            fieldDataAccess.Setup(x => x.GetByAsync(fieldContainer.Object)).ReturnsAsync((Field) null);

            var fieldGetService = new FieldGetService(fieldDataAccess.Object);

            //act
            var action = new Func<Task>(() => fieldGetService.ValidateAsync(fieldContainer.Object));

            //assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Field not found by id {id}");
        }
    }
}
