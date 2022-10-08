using Clean.Architecture.UseCases.Common.Ports;

namespace Clean.Architecture.Presenters
{
    public interface IPresenter<ResponseType, FormatType> : IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}