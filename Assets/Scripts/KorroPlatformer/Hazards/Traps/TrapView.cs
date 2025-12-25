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
        [SerializeField, Tooltip("Animator component for the trap.")]
        private Animator _Animator;

        /// <summary>
        /// Event triggered when the trap is activated.
        /// </summary>
        public event Action OnTrapTriggered;

        private TrapModel _Model;
        private TrapAnimationConfiguration _AnimConfig;

        private int _OpenStateHash;
        private int _ClosedStateHash;

        /// <summary>
        /// Initializes the trap view with the model.
        /// </summary>
        /// <param name="model">The trap model.</param>
        void IView<TrapModel>.Initialize(TrapModel model) => _Model = model;

        /// <summary>
        /// Initializes the trap view with the model and animation configuration.
        /// </summary>
        /// <param name="model">The trap model.</param>
        /// <param name="animConfig">The animation configuration.</param>
        public void Initialize(TrapModel model, TrapAnimationConfiguration animConfig)
        {
            _Model = model;
            _AnimConfig = animConfig;

            if (_AnimConfig != null)
            {
                _OpenStateHash = Animator.StringToHash(_AnimConfig.OpenStateName);
                _ClosedStateHash = Animator.StringToHash(_AnimConfig.ClosedStateName);
            }
        }

        /// <summary>
        /// Plays the close animation.
        /// </summary>
        public void PlayClose()
        {
            if (_Animator != null && _AnimConfig != null)
            {
                _Animator.CrossFade(_ClosedStateHash, _AnimConfig.CrossFadeDuration);
            }
        }

        /// <summary>
        /// Plays the open animation.
        /// </summary>
        public void PlayOpen()
        {
            if (_Animator != null && _AnimConfig != null)
            {
                _Animator.CrossFade(_OpenStateHash, _AnimConfig.CrossFadeDuration);
            }
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
