namespace Core.Crosscutting.Commands
{
    /// <summary>
    /// Contract of CommandHandler.
    /// </summary>
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
