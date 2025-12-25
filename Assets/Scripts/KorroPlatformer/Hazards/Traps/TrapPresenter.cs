using Common.Events;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Hazards.Traps
{
    /// <summary>
    /// Presenter for traps, mediating between model, view, and events.
    /// </summary>
    public class TrapPresenter : BasePresenter<TrapView, TrapModel>
    {
        private readonly IEventChannel _TrapTriggeredEvent;
        private readonly TrapAnimationConfiguration _Config;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrapPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="model">The model.</param>
        /// <param name="trapTriggeredEvent">The event triggered by the trap.</param>
        /// <param name="config">The animation configuration.</param>
        public TrapPresenter(TrapView view, TrapModel model, IEventChannel trapTriggeredEvent, TrapAnimationConfiguration config)
            : base(view, model)
        {
            _TrapTriggeredEvent = trapTriggeredEvent;
            _Config = config;
            View.OnTrapTriggered += HandleTrapTriggered;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            View.OnTrapTriggered -= HandleTrapTriggered;
        }

        private void HandleTrapTriggered()
        {
            _ = HandleTrapTriggeredAsync();
        }

        private async Awaitable HandleTrapTriggeredAsync()
        {
            if (Model.IsActive) return;

            Model.IsActive = true;

            // Raise event for damage
            if (_TrapTriggeredEvent != null)
            {
                _TrapTriggeredEvent.Raise();
            }

            // Play close animation
            View.PlayClose();

            // Wait before opening
            await Awaitable.WaitForSecondsAsync(_Config.StayClosedDuration);

            // Play open animation
            View.PlayOpen();
            Model.IsActive = false;
        }
    }
}
