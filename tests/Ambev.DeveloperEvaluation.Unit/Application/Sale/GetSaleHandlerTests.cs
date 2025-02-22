using FluentAssertions;
using NSubstitute;
using Xunit;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using SaleEntity = Ambev.DeveloperEvaluation.Domain.Entities.Sale;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Handlers
{
    public class GetSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetSaleHandler(_saleRepository, _mapper);
        }

        /// <summary>
        /// Verifica se o comando GetSale é processado corretamente quando a venda é encontrada.
        /// </summary>
        [Fact(DisplayName = "Dado um ID de venda válido Quando a venda é recuperada Então retorna os detalhes da venda")]
        public async Task Handle_ValidRequest_ReturnsSaleDetails()
        {
            // Given
            var command = new GetSaleCommand(Guid.NewGuid()); // Comando válido com ID de venda
            var sale = new SaleEntity
            {
                Id = command.Id,
                SaleDate = DateTime.UtcNow,
                TotalAmount = 100m,
                CustomerId = Guid.NewGuid(),
                BranchId = Guid.NewGuid()
            };

            var expectedResult = new GetSaleResult
            {
                Id = sale.Id,
                SaleDate = sale.SaleDate,
                TotalAmount = sale.TotalAmount
            };

            _saleRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns(sale);
            _mapper.Map<GetSaleResult>(sale).Returns(expectedResult);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expectedResult); // Verifica se o resultado é equivalente ao esperado
            await _saleRepository.Received(1).GetByIdAsync(command.Id, Arg.Any<CancellationToken>());
        }

        /// <summary>
        /// Verifica se uma exceção KeyNotFoundException é lançada quando a venda não é encontrada.
        /// </summary>
        [Fact(DisplayName = "Dado um ID de venda inválido Quando a venda não é encontrada Então lança exceção")]
        public async Task Handle_SaleNotFound_ThrowsKeyNotFoundException()
        {
            // Given
            var command = new GetSaleCommand(Guid.NewGuid()); // ID inválido que não será encontrado

            _saleRepository.GetByIdAsync(command.Id, Arg.Any<CancellationToken>()).Returns((SaleEntity)null!);

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
            var command = new GetSaleCommand(Guid.Empty); // Comando inválido (ID vazio)

            // When
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }
    }
}
