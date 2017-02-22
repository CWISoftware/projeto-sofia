namespace Sofia.SharedKernel.Commands
{
    /// <summary>
    /// Contract of CommandHandler.
    /// </summary>
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
