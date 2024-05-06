using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()// Меню стайт, Игровой стейт,
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this), 
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Exit();
        }
    }
}