using FluentAssertions;
using NSubstitute;
using Xunit;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.Handlers
{
    public class DeleteSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly DeleteSaleHandler _handler;

        public DeleteSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _handler = new DeleteSaleHandler(_saleRepository);
        }

        /// <summary>
        /// Verifica se o DeleteSaleHandler processa o comando com sucesso quando a venda é excluída corretamente.
        /// </summary>
        [Fact(DisplayName = "Dado um ID de venda válido Quando a venda é excluída Então retorna sucesso")]
        public async Task Handle_ValidRequest_DeletesSaleSuccessfully()
        {
            // Given
            var command = new DeleteSaleCommand(Guid.NewGuid());

            // Simulando que a venda foi excluída com sucesso
            _saleRepository.DeleteAsync(command.Id, Arg.Any<CancellationToken>()).Returns(true);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            result.Success.Should().BeTrue();
            await _saleRepository.Received(1).DeleteAsync(command.Id, Arg.Any<CancellationToken>());
        }


        /// <summary>
        /// Verifica se uma exceção é lançada quando o ID da venda não é encontrado.
        /// </summary>
        [Fact(DisplayName = "Dado um ID de venda inválido Quando a venda não é encontrada Então lança exceção")]
        public async Task Handle_SaleNotFound_ThrowsKeyNotFoundException()
        {
            // Given
            var command = new DeleteSaleCommand(Guid.NewGuid());

            // Simulando que a venda não foi encontrada
            _saleRepository.DeleteAsync(command.Id, Arg.Any<CancellationToken>()).Returns(false);

            // When
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage($"Sale with ID {command.Id} not found");
        }

        /// <summary>
        /// Verifica se o comando de exclusão falha quando não é validado corretamente.
        /// </summary>
        [Fact(DisplayName = "Dado um comando inválido Quando processado Então lança exceção de validação")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Given
            var command = new DeleteSaleCommand(Guid.Empty); // Usando Guid.Empty para simular um comando inválido (sem ID válido)

            // When
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Then
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }

    }
}
