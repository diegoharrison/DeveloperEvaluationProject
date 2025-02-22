using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;
using SaleEntity = Ambev.DeveloperEvaluation.Domain.Entities.Sale;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Handlers
{
    public class UpdateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly UpdateSaleHandler _handler;

        public UpdateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new UpdateSaleHandler(_saleRepository, _mapper);
        }

        /// <summary>
        /// Verifica se a venda e os itens são atualizados corretamente.
        /// </summary>
        [Fact(DisplayName = "Dado um comando de atualização válido Quando processado Então a venda é atualizada com sucesso")]
        public async Task Handle_ValidRequest_UpdatesSaleSuccessfully()
        {
            // Given
            var command = new UpdateSaleCommand
            {
                Id = Guid.NewGuid(),
                SaleDate = DateTime.UtcNow,
                CustomerId = Guid.NewGuid(),
                TotalAmount = 100m,
                BranchId = Guid.NewGuid(),
                Items = new List<SaleItemCommand> // Lista de itens a serem atualizados
                {
                    new SaleItemCommand
                    {
                        ProductId = 1,
                        ProductDescription = "Produto 1",
                        Quantity = 5,
                        UnitPrice = 10m,
                        Discount = 5m
                    }
                }
            };

            var existingSale = new SaleEntity
            {
                Id = command.Id,
                SaleDate = DateTime.UtcNow.AddDays(-1),
                CustomerId = Guid.NewGuid(),
                TotalAmount = 50m,
                BranchId = Guid.NewGuid(),
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = 1,
                        ProductDescription = "Produto 1",
                        Quantity = 3,
                        UnitPrice = 10m,
                        Discount = 5m
                    }
                }
            };

            var updatedSale = new SaleEntity
            {
                Id = command.Id,
                SaleDate = command.SaleDate,
                CustomerId = command.CustomerId,
                TotalAmount = command.TotalAmount,
                BranchId = command.BranchId,
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = 1,
                        ProductDescription = "Produto 1",
                        Quantity = 5,
                        UnitPrice = 10m,
                        Discount = 5m
                    }
                }
            };

            var expectedResult = new UpdateSaleResult
            {
                Id = updatedSale.Id,
                SaleDate = updatedSale.SaleDate,
                TotalAmount = updatedSale.TotalAmount,
                BranchId = updatedSale.BranchId
            };

            // Mocking repository and mapper behavior
            _saleRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns(existingSale);
            _mapper.Map<List<SaleItem>>(command.Items).Returns(updatedSale.Items);
            _mapper.Map<UpdateSaleResult>(updatedSale).Returns(expectedResult);
            _saleRepository.UpdateAsync(updatedSale, Arg.Any<CancellationToken>()).Returns(updatedSale);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expectedResult); // Verifica se o resultado é equivalente ao esperado
            await _saleRepository.Received(1).GetByIdAsync(command.Id, Arg.Any<CancellationToken>());
            await _saleRepository.Received(1).UpdateAsync(updatedSale, Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Verifica se uma exceção é lançada quando a venda não é encontrada.
        /// </summary>
        [Fact(DisplayName = "Dado um ID de venda inválido Quando a venda não é encontrada Então lança exceção")]
        public async Task Handle_SaleNotFound_ThrowsKeyNotFoundException()
        {
            // Given
            var command = new UpdateSaleCommand { Id = Guid.NewGuid() };

            _saleRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns((SaleEntity)null);

            // When
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage($"Sale with ID {command.Id} not found");
        }

        /// <summary>
        /// Verifica se uma exceção de validação é lançada quando o comando não é válido.
        /// </summary>
        [Fact(DisplayName = "Dado um comando inválido Quando processado Então lança exceção de validação")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = new UpdateSaleCommand { Id = Guid.Empty }; // Comando inválido (ID vazio)

            // When
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }
    }
}
