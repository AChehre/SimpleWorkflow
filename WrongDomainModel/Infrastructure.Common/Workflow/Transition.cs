namespace WrongDomainModel.Infrastructure.Common.Workflow
{
    public abstract class Transition<TState>
    {
        public readonly TState CurrentState;
        public readonly TState DestinationState;

        protected Transition(TState currentState, TState destinationState)
        {
            CurrentState = currentState;
            DestinationState = destinationState;
        }

        public override bool Equals(object obj)
        {
            return obj is Transition<TState> && this == (Transition<TState>) obj;
        }

        public override int GetHashCode()
        {
            var hashCode = 23 * 17 + CurrentState.GetHashCode();
            hashCode = hashCode * 17 + DestinationState.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Transition<TState> transitionx, Transition<TState> transitiony)
        {
            return transitionx.GetHashCode() == transitiony.GetHashCode();
        }
        public static bool operator !=(Transition<TState> transitionx, Transition<TState> transitiony)
        {
            return transitionx.GetHashCode() == transitiony.GetHashCode();
        }
        public override string ToString()
        {
            return $"Transition: {CurrentState} => {DestinationState} HashCode: {GetHashCode()}";
        }
    }
}