using MediatR;

namespace Clean.Architecture.UseCases.Common.Ports
{
    public interface IInputPort<InteractorRequestType, InteractorResponseType>
        : IRequest
    {
        InteractorRequestType Data { get; }
        IOutputPort<InteractorResponseType> OutputPort { get; }
    }
}
