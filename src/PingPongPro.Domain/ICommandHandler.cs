namespace PingPongPro.Domain
{
    public interface ICommandHandler<in TCommand> where TCommand:ICommand
    {
        void Procces(TCommand command);
    }
}