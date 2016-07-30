namespace HeavenlyPizzeriaWebUI
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}