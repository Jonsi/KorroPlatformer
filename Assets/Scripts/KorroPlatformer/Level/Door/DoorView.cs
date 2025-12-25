using System;
using Common;
using Common.Interaction;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Level.Door
{
    /// <summary>
    /// View component for the Door, handling visual updates and interaction input.
    /// </summary>
    public class DoorView : MonoBehaviour, IView<DoorModel>, IInteractable, IDoorAnimator
    {
        [SerializeField, Tooltip("Animator component for the door.")] 
        private Animator _Animator;

        private DoorModel _Model;
        private DoorAnimationConfiguration _AnimConfig;
        
        private int _OpenStateHash;

        /// <summary>
        /// Event raised when an interaction is requested.
        /// </summary>
        public event Action InteractionRequested;

        /// <summary>
        /// Initializes the door view with model and configuration.
        /// </summary>
        /// <param name="model">The door model.</param>
        /// <param name="animConfig">The animation configuration.</param>
        public void Initialize(DoorModel model, DoorAnimationConfiguration animConfig)
        {
            _Model = model;
            _AnimConfig = animConfig;
            
            _OpenStateHash = Animator.StringToHash(_AnimConfig.OpenStateName);
        }

        void IView<DoorModel>.Initialize(DoorModel model) => _Model = model;

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

        /// <inheritdoc />
        public void Interact()
        {
            InteractionRequested?.Invoke();
        }

        /// <inheritdoc />
        public void PlayOpen()
        {
            if (_Animator != null)
            {
                _Animator.CrossFade(_OpenStateHash, _AnimConfig.CrossFadeDuration);
            }
        }
    }
}
