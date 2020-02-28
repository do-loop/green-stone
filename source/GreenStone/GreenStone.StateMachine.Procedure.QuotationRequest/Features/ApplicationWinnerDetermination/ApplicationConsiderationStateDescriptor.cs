﻿namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination
{
    using Models;

    /// <inheritdoc />
    public sealed class ApplicationWinnerDeterminationStateDescriptor : ProcedureStateDescriptor<ApplicationWinnerDeterminationState>
    {
        /// <inheritdoc />
        public override bool Selectable(Procedure subject)
        {
            return subject.State == ProcedureStateEnum.ApplicationWinnerDetermination;
        }
    }
}