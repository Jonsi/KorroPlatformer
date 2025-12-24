using System;
using Common;
using Common.MVP;
using UnityEngine;

namespace KorroPlatformer.Hazards.Traps
{
    public class TrapView : MonoBehaviour, IView<TrapModel>
    {
        public event Action OnTrapTriggered;

        private TrapModel _Model;

        public void Initialize(TrapModel model)
        {
            _Model = model;
        }

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
