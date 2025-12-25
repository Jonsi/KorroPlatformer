using Common.Events;
using Common.MVP;

namespace KorroPlatformer.Hazards.Traps
{
    /// <summary>
    /// Presenter for traps, mediating between model, view, and events.
    /// </summary>
    public class TrapPresenter : BasePresenter<TrapView, TrapModel>
    {
        private readonly IEventChannel _TrapTriggeredEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrapPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="model">The model.</param>
        /// <param name="trapTriggeredEvent">The event triggered by the trap.</param>
        public TrapPresenter(TrapView view, TrapModel model, IEventChannel trapTriggeredEvent) 
            : base(view, model)
        {
            _TrapTriggeredEvent = trapTriggeredEvent;
            View.OnTrapTriggered += HandleTrapTriggered;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            View.OnTrapTriggered -= HandleTrapTriggered;
        }

        private void HandleTrapTriggered()
        {
            if (_TrapTriggeredEvent != null)
            {
                _TrapTriggeredEvent.Raise();
            }
        }
    }
}
