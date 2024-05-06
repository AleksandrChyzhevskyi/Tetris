namespace DefaultNamespace
{
    public class Game
    {
        public readonly GameStateMachine _stateMachine;

        public Game()
        {
            _stateMachine = new GameStateMachine();
        }
    }
}