using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Application.Sales.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<CreateSaleHandler> _logger;

    public CreateSaleHandler(ISaleRepository saleRepository, ILogger<CreateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _logger = logger;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        // Aplicar regras de negócio
        foreach (var item in command.Items)
        {
            if (item.Quantity > 20)
            {
                throw new InvalidOperationException("Não é possível vender mais de 20 itens idênticos.");
            }

            if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                item.Discount = item.UnitPrice * item.Quantity * 0.20m; // 20% de desconto
            }
            else if (item.Quantity >= 4 && item.Quantity < 10)
            {
                item.Discount = item.UnitPrice * item.Quantity * 0.10m; // 10% de desconto
            }
            else
            {
                item.Discount = 0; // Sem desconto
            }

            // Calcular o TotalItemAmount usando o método CalculateTotalItemAmount
            // Atribuindo o valor diretamente não é mais permitido, então a alteração foi feita para usar o cálculo.
            var totalItemAmount = item.CalculateTotalItemAmount();
        }

        // Criar a venda
        var sale = new Sale
        {
            SaleDate = command.SaleDate,
            CustomerId = command.CustomerId,
            // Calcular o TotalAmount usando a função
            TotalAmount = command.Items.Sum(item => item.CalculateTotalItemAmount()),
            BranchId = command.BranchId,
            Items = command.Items.Select(item => new SaleItem
            {
                ProductId = item.ProductId,
                ProductDescription = item.ProductDescription,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Discount = item.Discount,
                // Calcular o TotalItemAmount para cada item
                TotalItemAmount = item.CalculateTotalItemAmount()
            }).ToList()
        };

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        // Publicar evento de venda criada
        var saleCreatedEvent = new SaleCreatedEvent
        {
            SaleId = createdSale.Id,
            SaleDate = createdSale.SaleDate,
            CustomerId = createdSale.CustomerId,
            TotalAmount = createdSale.TotalAmount
        };

        _logger.LogInformation("Sale created: {@SaleCreatedEvent}", saleCreatedEvent);

        // Retornar o resultado
        // Retornar o resultado
        // Retornar o resultado
        return new CreateSaleResult
        {
            Id = createdSale.Id,
            SaleDate = createdSale.SaleDate,
            TotalAmount = createdSale.TotalAmount,
            Items = createdSale.Items.Select(item => new SaleItemResult
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductDescription = item.ProductDescription,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Discount = item.Discount,
            }).ToList(),
            IsCancelled = createdSale.IsCancelled
        };


    }
}
