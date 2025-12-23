using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers.Commands
{
    public class CreateCheckoutOrderCommandHandler : IRequestHandler<CreateCheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCheckoutOrderCommandHandler> _logger;

        public CreateCheckoutOrderCommandHandler(
            IOrderRepository orderRepository,
            IMapper mapper,
            ILogger<CreateCheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<int> Handle(CreateCheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var generatedOrder = await _orderRepository.AddAsync(orderEntity);
            _logger.LogInformation($"Order with Id {generatedOrder.Id} successfully created");

            return generatedOrder.Id;
        }
    }
}
