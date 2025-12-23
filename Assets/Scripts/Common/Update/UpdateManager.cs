using System.Collections.Generic;
using UnityEngine;

namespace Common.Update
{
    public class UpdateManager : MonoBehaviour
    {
        private readonly List<IUpdatable> _updatables = new List<IUpdatable>();

        private void Update()
        {
            for (int i = _updatables.Count - 1; i >= 0; i--)
            {
                _updatables[i].Update();
            }
        }

        public void Register(IUpdatable obj) => _updatables.Add(obj);
        public void Unregister(IUpdatable obj) => _updatables.Remove(obj);
    }
}

