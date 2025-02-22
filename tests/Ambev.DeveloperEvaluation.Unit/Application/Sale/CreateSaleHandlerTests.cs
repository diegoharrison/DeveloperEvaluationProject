using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using NSubstitute;
using Xunit;
using SaleEntity = Ambev.DeveloperEvaluation.Domain.Entities.Sale;


namespace Ambev.DeveloperEvaluation.Unit.Application.Sale;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _handler = new CreateSaleHandler(_saleRepository, null);
    }

    /// <summary>
    /// Verifica se o valor total da venda é calculado corretamente.
    /// </summary>
    [Fact(DisplayName = "Dada uma venda válida Quando processada Então o valor total é calculado corretamente")]
    public async Task Handle_ValidRequest_CalculatesTotalAmountCorrectly()
    {
        // Given
        var command = new CreateSaleCommand
        {
            SaleDate = DateTime.UtcNow,
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<CreateSaleItemCommand>
            {
                new CreateSaleItemCommand
                {
                    ProductId = 1,
                    ProductDescription = "Produto 1",
                    Quantity = 5,
                    UnitPrice = 10m,
                    Discount = 5m
                },
                new CreateSaleItemCommand
                {
                    ProductId = 2,
                    ProductDescription = "Produto 2",
                    Quantity = 3,
                    UnitPrice = 20m,
                    Discount = 0m
                }
            }
        };

        var expectedTotalAmount = 5 * 10m - 5m + 3 * 20m; // (5 * 10 - 5) + (3 * 20)

        var sale = new SaleEntity
        {
            Id = Guid.NewGuid(),
            SaleDate = command.SaleDate,
            TotalAmount = expectedTotalAmount,
            CustomerId = command.CustomerId,
            BranchId = command.BranchId,
            IsCancelled = false,
            Items = new List<SaleItem>
            {
                new SaleItem
                {
                    ProductId = 1,
                    ProductDescription = "Produto 1",
                    Quantity = 5,
                    UnitPrice = 10m,
                    Discount = 5m
                },
                new SaleItem
                {
                    ProductId = 2,
                    ProductDescription = "Produto 2",
                    Quantity = 3,
                    UnitPrice = 20m,
                    Discount = 0m
                }
            }
        };

        _saleRepository.CreateAsync(Arg.Any<SaleEntity>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.TotalAmount.Should().Be(expectedTotalAmount);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<SaleEntity>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Verifica se o repositório é chamado corretamente para salvar a venda.
    /// </summary>
    [Fact(DisplayName = "Dada uma venda válida Quando processada Então o repositório é chamado")]
    public async Task Handle_ValidRequest_CallsSaleRepository()
    {
        // Given
        var command = new CreateSaleCommand
        {
            SaleDate = DateTime.UtcNow,
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<CreateSaleItemCommand>
            {
                new CreateSaleItemCommand
                {
                    ProductId = 1,
                    ProductDescription = "Produto 1",
                    Quantity = 5,
                    UnitPrice = 10m,
                    Discount = 5m
                }
            }
        };

        var sale = new SaleEntity
        {
            Id = Guid.NewGuid(),
            SaleDate = command.SaleDate,
            TotalAmount = 50m,
            CustomerId = command.CustomerId,
            BranchId = command.BranchId,
            IsCancelled = false,
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

        _saleRepository.CreateAsync(Arg.Any<SaleEntity>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        await _saleRepository.Received(1).CreateAsync(Arg.Any<SaleEntity>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Verifica se o valor do total da venda é calculado corretamente com desconto.
    /// </summary>
    [Fact(DisplayName = "Dada uma venda com desconto Quando processada Então o valor total deve ser calculado com o desconto")]
    public async Task Handle_ValidRequest_CalculatesTotalAmountWithDiscount()
    {
        // Given
        var command = new CreateSaleCommand
        {
            SaleDate = DateTime.UtcNow,
            CustomerId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
            Items = new List<CreateSaleItemCommand>
            {
                new CreateSaleItemCommand
                {
                    ProductId = 1,
                    ProductDescription = "Produto 1",
                    Quantity = 10,
                    UnitPrice = 15m,
                    Discount = 10m // Desconto aplicado
                }
            }
        };

        var expectedTotalAmount = 10 * 15m - 10m; // 10 * 15 - 10

        var sale = new SaleEntity
        {
            Id = Guid.NewGuid(),
            SaleDate = command.SaleDate,
            TotalAmount = expectedTotalAmount,
            CustomerId = command.CustomerId,
            BranchId = command.BranchId,
            IsCancelled = false,
            Items = new List<SaleItem>
            {
                new SaleItem
                {
                    ProductId = 1,
                    ProductDescription = "Produto 1",
                    Quantity = 10,
                    UnitPrice = 15m,
                    Discount = 10m
                }
            }
        };

        _saleRepository.CreateAsync(Arg.Any<SaleEntity>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.TotalAmount.Should().Be(expectedTotalAmount);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<SaleEntity>(), Arg.Any<CancellationToken>());
    }
}
