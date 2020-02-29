namespace GreenStone.StateMachine.Application
{
    using System.Collections.Generic;
    using Models;

    /// <inheritdoc />
    public sealed class ApplicationStateMachine : StateMachine<Application>
    {
        /// <inheritdoc />
        public ApplicationStateMachine(IEnumerable<IState<Application>> states) : base(states) { }
    }
}