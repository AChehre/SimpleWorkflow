using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Workflow
{
    public abstract class Workflow<TState>
    {
        private readonly Lazy<Dictionary<Transition<TState>, ICommand>> _transitions;
        protected Workflow()
        {
            _transitions = new Lazy<Dictionary<Transition<TState>, ICommand>>();
        }

        protected void RegisterTransition(Transition<TState> transition, ICommand stateCommand)
        {
            _transitions.Value.Add(transition, stateCommand);
        }

        protected ICommand GetCommand(Transition<TState> transition)
        {
            ICommand stateCommand;
            _transitions.Value.TryGetValue(transition, out stateCommand);
            return stateCommand;
        }

    }
}
