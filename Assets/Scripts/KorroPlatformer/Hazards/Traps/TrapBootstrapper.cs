using Common.Events;
using UnityEngine;

namespace KorroPlatformer.Hazards.Traps
{
    /// <summary>
    /// Bootstrapper for traps.
    /// </summary>
    public class TrapBootstrapper : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the Trap View.")]
        private TrapView _View;

        [Tooltip("The amount of damage this trap inflicts.")]
        [SerializeField] private int _Damage = 1;

        [Header("Dependencies")]
        [SerializeField, Tooltip("Event raised when trap triggers.")] 
        private VoidEventChannel _TrapTriggeredEvent;

        private TrapPresenter _Presenter;

        private void Start()
        {
            var model = new TrapModel(_Damage);

            if (_View == null) _View = GetComponent<TrapView>();
            _View.Initialize(model);

            _Presenter = new TrapPresenter(_View, model, _TrapTriggeredEvent);
        }

        private void OnDestroy()
        {
            _Presenter?.Dispose();
        }

        private void Reset()
        {
            _View = GetComponent<TrapView>();
        }
    }
}
