using Clean.Architecture.DTOs.CreateOrder;
using Clean.Architecture.UseCases.Common.Ports;
using MediatR;

namespace Clean.Architecture.UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrderDto, int>
    {
        public CreateOrderInputPort(
            CreateOrderDto data, IOutputPort<int> outputPort) =>
            (Data, OutputPort) = (data, outputPort);

        public CreateOrderDto Data { get; private set; }

        public IOutputPort<int> OutputPort { get; private set; }
    }
}
