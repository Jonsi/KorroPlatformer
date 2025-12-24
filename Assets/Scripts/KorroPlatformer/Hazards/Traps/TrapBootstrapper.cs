using Common.Events;
using UnityEngine;

namespace KorroPlatformer.Hazards.Traps
{
    public class TrapBootstrapper : MonoBehaviour
    {
        [SerializeField] private TrapView _View;

        [Tooltip("The amount of damage this trap inflicts.")]
        [SerializeField] private int _Damage = 1;

        [Header("Dependencies")]
        [SerializeField] private VoidEventChannel _TrapTriggeredEvent;

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
