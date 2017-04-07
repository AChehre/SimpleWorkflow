using System;
using System.Collections.Generic;
using WrongDomainModel.Infrastructure.Common.Workflow;

namespace Domain.Model
{
    public class StateMachine<TState>
    {
        private readonly HashSet<Transition<TState>> _transitions;

        public StateMachine()
        {
            _transitions = new HashSet<Transition<TState>>();
        }

        public void RegisterTransition(Transition<TState> transition)
        {
            if (!_transitions.Add(transition))
                throw new ArgumentException(transition.ToString());
        }

        public bool HasTransition(Transition<TState> transition)
        {
            return _transitions.Contains(transition);
        }
    }
}