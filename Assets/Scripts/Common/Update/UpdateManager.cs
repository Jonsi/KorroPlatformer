using System.Collections.Generic;
using UnityEngine;

namespace Common.Update
{
    /// <summary>
    /// Centralizes update callbacks for registered objects.
    /// </summary>
    public class UpdateManager : MonoBehaviour
    {
        private readonly List<IUpdatable> _Updatables = new List<IUpdatable>();

        private void Update()
        {
            for (int i = _Updatables.Count - 1; i >= 0; i--)
            {
                _Updatables[i].Update();
            }
        }

        /// <summary>
        /// Registers an object to receive update callbacks.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        public void Register(IUpdatable obj) => _Updatables.Add(obj);

        /// <summary>
        /// Unregisters an object so it no longer receives update callbacks.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public void Unregister(IUpdatable obj) => _Updatables.Remove(obj);
    }
}
