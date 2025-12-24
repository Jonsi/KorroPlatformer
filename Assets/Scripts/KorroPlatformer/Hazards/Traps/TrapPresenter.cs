using Common.Events;
using Common.MVP;

namespace KorroPlatformer.Hazards.Traps
{
    public class TrapPresenter : BasePresenter<TrapView, TrapModel>
    {
        private readonly VoidEventChannel _TrapTriggeredEvent;

        public TrapPresenter(TrapView view, TrapModel model, VoidEventChannel trapTriggeredEvent) 
            : base(view, model)
        {
            _TrapTriggeredEvent = trapTriggeredEvent;
            View.OnTrapTriggered += HandleTrapTriggered;
        }

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
