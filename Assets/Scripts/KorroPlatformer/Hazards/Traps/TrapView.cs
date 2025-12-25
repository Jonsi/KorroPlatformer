using System;
using Common;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Hazards.Traps
{
    /// <summary>
    /// View component for a trap that deals damage on collision.
    /// </summary>
    public class TrapView : MonoBehaviour, IView<TrapModel>
    {
        /// <summary>
        /// Event triggered when the trap is activated.
        /// </summary>
        public event Action OnTrapTriggered;

        private TrapModel _Model;

        /// <summary>
        /// Initializes the trap view with the model.
        /// </summary>
        /// <param name="model">The trap model.</param>
        public void Initialize(TrapModel model)
        {
            _Model = model;
        }

        /// <inheritdoc />
        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        /// <inheritdoc />
        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_Model == null) return;

            if (other.TryGetComponent(out IHitable hitable))
            {
                hitable.TakeDamage(_Model.Damage);
                OnTrapTriggered?.Invoke();
            }
        }
    }
}
