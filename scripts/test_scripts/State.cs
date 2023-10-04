public abstract class State
{
    public abstract void EnterState();

    public abstract void TickState(float deltaTime);

    public abstract void ExitState();
}