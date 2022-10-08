namespace Clean.Architecture.UseCases.Common.Ports
{
    public interface IOutputPort<InteratorResponseType>
    {
        void Handle(InteratorResponseType response);
    }
}
