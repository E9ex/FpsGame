public abstract class BaseState
{
    public statemachine Statemachine;
    public Enemy enemy;
    public abstract void enter();
    public abstract void perform();
    public abstract void exit();
}
