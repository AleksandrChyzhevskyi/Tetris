namespace DefaultNamespace
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
        }

        public void Exit()
        {
        }
    }
}