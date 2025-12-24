using System;
using Common;
using Common.Interaction;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Level.Door
{
    public class DoorView : MonoBehaviour, IView<DoorModel>, IInteractable, IDoorAnimator
    {
        [SerializeField] private Animator _Animator;

        private DoorModel _Model;
        private DoorAnimationConfiguration _AnimConfig;
        
        private int _OpenStateHash;
        private int _ClosedStateHash;

        public event Action InteractionRequested;

        public void Initialize(DoorModel model, DoorAnimationConfiguration animConfig)
        {
            _Model = model;
            _AnimConfig = animConfig;
            
            _OpenStateHash = Animator.StringToHash(_AnimConfig.OpenStateName);
            _ClosedStateHash = Animator.StringToHash(_AnimConfig.ClosedStateName);
        }

        void IView<DoorModel>.Initialize(DoorModel model) => _Model = model;

        public Awaitable Show()
        {
            gameObject.SetActive(true);
            return AwaitableUtility.Completed();
        }

        public Awaitable Hide()
        {
            gameObject.SetActive(false);
            return AwaitableUtility.Completed();
        }

        public void Interact()
        {
            InteractionRequested?.Invoke();
        }

        public void PlayOpen()
        {
            if (_Animator != null)
            {
                _Animator.CrossFade(_OpenStateHash, _AnimConfig.CrossFadeDuration);
            }
        }

        public void PlayClosed()
        {
            if (_Animator != null)
            {
                _Animator.CrossFade(_ClosedStateHash, _AnimConfig.CrossFadeDuration);
            }
        }
    }
}

